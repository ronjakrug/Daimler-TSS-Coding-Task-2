# Daimler-TSS-Coding-Task-2
Developer Task for Implementing an "Intervall MERGE"

In the first step the Interval class was implemented. It has the attributes "start" and "end" and in case the duration is needed some time it has a attribute "length". There is also a possibility to ignore the order of the start and the end, so that the smaller number is set to the start automatically, which is the default. If it's set to not ignore, it will sent an exception if the start value is greater than the end value.
Inside of the "Interval" class there is a enum "IntersectionCase" which represents every possible case of an intersection between two intervals. For getting an overview of the possible cases a chart was drawn, you can find it in the pictures folder inside of the project.
Furthermore there is a function "Compare" in it, which compares two intervals and returns the correct value of the enum. And there is a function "Merge" which calls the Compare function and returns a merged list of intervals.

While programming I realized, that after at first sorting the List we want to merge, two of the 4 cases will be evaluated. There are only the cases "A intersects B" and "B within A" left. I didn't remove the code parts to maintain the overall view.
Every possible case has been tested and a big amount of Intervals in the interval list too. 
The execution time of the "Merge" method was approximately 30-40ms with a small ammount of data and 60-80ms with 10000 intervals in the list.

I found another possible solution which would fit great, implemented by Jianmin Chen on github https://gist.github.com/jianminchen/7a2778829ccb31210d8850e581a99048 using the IComparer interface. It would be a beautiful solution in that way too. 
