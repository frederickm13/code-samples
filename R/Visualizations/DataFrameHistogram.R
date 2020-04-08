#####
#Please input information below:

  #Define ggplot2 and data frame
library(ggplot2)
dFrame <- data.frame(#insert data frame here#)

  #insert x-axis variable below:
xAxisVar <- dFrame$#insert x-axis variable here#

  #insert x-axis label string below:
xAxisLabel <- "X Label Here"

  #insert title string below:
titleVar <- "Title Here"

  #add sorting variable below (not necessary unless running the commands utilizing this):
sortingVar <- dFrame$#insert sorting variable here#

#####

#Check structure of dataframe
str(dFrame)

#Creating initial base layer plot
initialPlot <- ggplot(dFrame, aes(xAxisVar))

#Create histogram
initialPlot + geom_histogram() + labs(title = titleVar, x = xAxisLabel, y = "Count")

#Change color by sorting variable (if provided)
initialPlot + geom_histogram(aes(fill = sortingVar)) + labs(title = titleVar, x = xAxisLabel, y = "Count")
