#2. Razmerje uspešnih/zgrešenih metov
HPM <- vector()
hpm <- teams$H2PM + teams$H3PM
hpa <- teams$H2PA + teams$H3PA
HPM <- hpm/hpa
teams$HPM <- as.factor(HPM)

APM <- vector()
apm <- teams$A2PM + teams$A3PM
apa <- teams$A2PA + teams$A3PA
APM <- apm/apa
teams$APM <- as.factor(APM)

# Razmerje ukradenih/izgubljenih žog
HB <- vector()
hstl <- teams$HSTL
htvo <- teams$HTOV
rate <- hstl / htvo
HB <- rate
teams$HB <- as.factor(HB)
summary(teams)

AB <- vector()
astl <- teams$ASTL
atvo <- teams$ATOV
rate <- astl / atvo
AB <- rate
teams$AB <- as.factor(AB)
summary(teams)

## ^ uporabimo pri grajenju 2. modela ^ ##

setwd("E:/UI/Seminarska")
teams <- read.table(file = 'regular.txt', header = T, sep = ',')

#	definiramo zmagovalca glede na št toèk
WIN <- vector()
h <- teams$HPTS
a <- teams$APTS
WIN[h < a] <- 'Away'
WIN[h > a] <- 'Home'
teams$WIN <- as.factor(WIN)

#Veèinski razred
learn <- teams[teams$SEASON != '2016-17',]
test <- teams[teams$SEASON == '2016-17',]
learn$SEASON <- NULL
test$SEASON <- NULL
nrow(learn)
nrow(test)

majority.class <- names(which.max(table(learn$WIN)))
sum(test$WIN == majority.class) / length(test$WIN)

#	Odloèitveno drevo
install.packages("rpart")
library(rpart)
dt <- rpart(WIN ~ ., data = learn)
dt
plot(dt)
text(dt, pretty = 0)

observed <- test$WIN
observed

predicted <- predict(dt, test, type = "class")
predicted

t <- table(observed, predicted)
t

CA <- function(prave, napovedane)
{
	t <- table(prave, napovedane)

	sum(diag(t)) / sum(t)
}
CA(observed, predicted)

install.packages("ipred")
library(ipred)
mypredict.generic <- function(object, newdata){predict(object, newdata, type = "class")}
mymodel.coremodel <- function(formula, data, target.model){CoreModel(formula, data, model=target.model)}
mypredict.coremodel <- function(object, newdata) {pred <- predict(object, newdata)$class; destroyModels(object); pred}


#	Naivni brier
install.packages("e1071")
library(e1071)

nb <- naiveBayes(WIN ~ ., data = learn)
predicted <- predict(nb, test, type="class")
CA(observed, predicted)
predMat <- predict(nb, test, type = "raw")
errorest(WIN~., data=learn, model = naiveBayes, predict = mypredict.generic)


#	Random Forest
install.packages("randomForest")
library(randomForest)

rf <- randomForest(WIN ~ ., data = learn)
predicted <- predict(rf, test, type="class")
CA(observed, predicted)

predMat <- predict(rf, test, type = "prob")

mypredict.rf <- function(object, newdata){predict(object, newdata, type = "class")}
errorest(WIN~., data=learn, model = randomForest, predict = mypredict.generic)


#	Kombiniranje algoritmov strojnega ucenja

sel <- sample(1:nrow(teams), size=as.integer(nrow(teams)*0.7), replace=F)
learn <- teams[sel,]
test <- teams[-sel,]

table(learn$WIN)
table(test$WIN)

#install.packages("CORElearn")
library(CORElearn)
source("funkcije.R")


#	Glasovanje

modelDT <- CoreModel(WIN ~ ., learn, model="tree")
modelNB <- CoreModel(WIN ~ ., learn, model="bayes")
modelKNN <- CoreModel(WIN ~ ., learn, model="knn", kInNN = 5)

predDT <- predict(modelDT, test, type = "class")
caDT <- CA(test$WIN, predDT)
caDT

predNB <- predict(modelNB, test, type="class")
caNB <- CA(test$WIN, predNB)
caNB

predKNN <- predict(modelKNN, test, type="class")
caKNN <- CA(test$WIN, predKNN)
caKNN

pred <- data.frame(predDT, predNB, predKNN)
pred


voting <- function(predictions)
{
	res <- vector()

  	for (i in 1 : nrow(predictions))  	
	{
		vec <- unlist(predictions[i,])
    		res[i] <- names(which.max(table(vec)))
  	}

  	factor(res, levels=levels(predictions[,1]))
}

predicted <- voting(pred)
CA(test$WIN, predicted)

#	tezeno glasovanje

predDT.prob <- predict(modelDT, test, type="probability")
predNB.prob <- predict(modelNB, test, type="probability")
predKNN.prob <- predict(modelKNN, test, type="probability")

pred.prob <- caDT * predDT.prob + caNB * predNB.prob + caKNN * predKNN.prob
pred.prob

# izberemo razred z najvecjo verjetnostjo
predicted <- levels(learn$WIN)[apply(pred.prob, 1, which.max)]

CA(test$WIN, predicted)




#
# Bagging
#

instal.packages("ipred")
library(ipred)

bag <- bagging(WIN ~ ., learn, nbagg=15)
bag.pred <- predict(bag, test, type="class")
CA(test$WIN, bag.pred)


#
# Boosting
#

install.packages("adabag")
library(adabag)

bm <- boosting(WIN ~ ., learn)
predictions <- predict(bm, test)

predicted <- predictions$class
CA(test$WIN, predicted)


#3.
#	Ocenjevanje atributov

sort(attrEval(WIN ~ ., teams, "InfGain"), decreasing = TRUE)
sort(attrEval(WIN ~ ., teams, "Gini"), decreasing = TRUE)

sort(attrEval(WIN ~ ., teams, "GainRatio"), decreasing = TRUE)

sort(attrEval(WIN ~ ., teams, "ReliefFequalK"), decreasing = TRUE)
sort(attrEval(WIN ~ ., teams, "MDL"), decreasing = TRUE)

# Funkciji za gradnjo modela in predikcijo, ki ju zelimo uporabiti pri precnem preverjanju  
mymodel <- function(formula, data, target.model){CoreModel(formula, data, model=target.model)}
mypredict <- function(object, newdata) {pred <- predict(object, newdata)$class; destroyModels(object); pred}

# 10-kratno precno preverjanje modela, ki uporablja samo bolje ocenjene atribute
res <- errorest(WIN ~ APTS + HPTS + HDRB + AFTM + HPF + HOME, AWAY, data = test, model = mymodel, predict = mypredict, target.model="tree")
1-res$error

res <- errorest(WIN ~ APTS + HPTS + HDRB + AFTM + HPF + AORB, data = test, model = mymodel, predict = mypredict, target.model="tree")
1-res$error

source("wrapper.R")
wrapper(test, className="WIN", classModel="tree", folds=10)
best model: estimated accuracy =  0.9873984 , selected feature subset =  WIN ~ APTS + HPTS + HDRB + ABLK + A3PM 

res <- errorest(WIN ~ APTS + HPTS + HDRB + ABLK, data = test, model = mymodel, predict = mypredict, target.model="tree")
1-res$error
