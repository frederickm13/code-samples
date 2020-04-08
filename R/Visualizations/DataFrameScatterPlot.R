#####
#Please input information below:

  #Define ggplot2 and data frame
library(ggplot2)
dFrame <- data.frame(#insert dataframe here#)
  
  #insert x-axis variable below:
xAxisVar <- dFrame$#insert here#
  
  #insert x-axis label string below:
xAxisLabel <- "X label Here"
  
  #insert y-axis variable below:
yAxisVar <- dFrame$#insert here#

  #insert x-axis label string below:
yAxisLabel <- "Y label Here"
  
  #insert title string below:
titleVar <- "Title Here"

  #add sorting variable below (not necessary unless running the commands utilizing this):
sortingVar <- dFrame$#insert here#

#####

#Check structure of dataframe
str(dFrame)

#Creating initial base layer plot
initialPlot <- ggplot(dFrame)

#Create scatter plot
initialPlot + geom_point(aes(x = xAxisVar, y = yAxisVar)) + labs(title = titleVar, x = xAxisLabel, y = yAxisLabel)

#Color by sortingVar
initialPlot + geom_point(aes(x = xAxisVar, y = yAxisVar, color = sortingVar)) + labs(title = titleVar, x = xAxisLabel, y = yAxisLabel)

#Add line of best fit
initialPlot + geom_point(aes(x = xAxisVar, y = yAxisVar)) + geom_smooth(method = lm, aes(x = xAxisVar, y = yAxisVar)) + labs(title = titleVar, x = xAxisLabel, y = yAxisLabel)
