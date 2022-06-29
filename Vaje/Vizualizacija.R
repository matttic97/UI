# nastavitev direktorija
setwd("E:/UI/Vaje")

# # Branje podatkov iz tekstovne datoteke
# (header=T oznacuje, da datoteka vsebuje vrstico z imeni atributov (stolpcev v podatkovnem okvirju)
#  sep="," doloca, da je znak "," uporabljen kot locilo med vrednostmi v datoteki)
md <- read.table(file = "movies.txt", sep = ",", header = T)

# nekaj uporabnih funkcij
head(md)
summary(md)
str(md)
names(md)

# Binarne atribute transformiramo v nominalne (faktoriziramo jih)
md$Action <- as.factor(md$Action)
md$Animation <- as.factor(md$Animation)

# Preostale atribute (stolpce) faktoriziramo v "for" zanki.
for (i in 20:24)
  md[,i] <- as.factor(md[,i])
