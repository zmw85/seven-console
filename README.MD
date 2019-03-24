# Seven Console App

- [Summary](#summary)
- [Other design considerations](#other-design-considerations)
- [How to run](#how-to-run)
- [Things can be improved](#things-can-be-improved)

### Summary

The Console App uses producer/consumer design pattern to generate multiple reports by reading through source data file just one. The time complexity is linear, in Big O will be O(n) regardless the number of reports need to be generated for a given source file.

![producer consumer design pattern](https://raw.githubusercontent.com/zmw85/seven-console/develop/data/producer_consumer.jpg)

The producer uses JsonTextReader to read through the source file record-by-record for registered consumers to collect or filter, each consumer is responsible for populating one report, and the report result is stored in the consumer.

### Other design considerations

- Dependency injection is used for more organizable & testable code.
- The buffer is used when reading through the file, so the memory usage for different file sizes will be constant, in Big O will be O(1).
- In consideration of large file size, the result for comma separated first name for age 23 can be capped in lines by changing configuration `Reports:UserReport:ReportMaxLines`, otherwise it can be push out of console buffer in my tests.
- Data formats & sources can be added easily in current structure, but it only supports JSON & local file at the moment.

### How to run

This console application was built using dotnetcore2.2, it has been tested on both Windows 10 & Mac. Before running this console app please change `Reports:UserReport:SourceUri` in `appsettings.json` to the absolute path based on where you clone the repository to.

**Examples:**

##### Windows
```posh
"SourceUri": "file:///D:/Projects/Others/seven-console/data/example_data.json",
```

or

##### Mac
```posh
"SourceUri": "file:///Users/zhengmin/projects/seven-console/data/example_data.json",
```

Parameters for reports can also be changed in `appsettings.json`.

### Things can be improved

- Unit tests don't cover every function, they can be added if needed.
- I spent some time try to put in integration test to test final console output, but didn't succeed. Still need to do some research to find out the proper way of doing it. I have done integration test for dotnetcore web app by running local web host, but never done one for console app.
- Consumer cannot quit the producer if all consumers have finished the job, e.g.: if all consumers are looking for first matched record. But the feature is not needed in this demo.