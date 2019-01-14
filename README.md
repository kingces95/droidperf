# Android Startup Performance
Xamarin management has identified Android startup performance as our top issue. 

This repository will host performance tests we'll use to capture profiles so we can compare Xamarin Android's start up performance with our competitors and identify those areas in need of performance work. 

For starters, our approach will be to create minimum viable applications, (e.g. a "Hello World" applications) for those scenarios we support and care to compare ourselves against. At a minimum, the scenarios are: 
* The Xamarin Forms Android template project
* The Xamarin Android template project
* A native Java Android project

We'll instrument roughly for starters. For example [this customer][1] simply used `Java.Lang.JavaSystem.CurrentTimeMillis()` to time the difference between `onCreate` and `onResume`. While that does not even capture the entire startup stack, it was sufficient to get this project off the ground. So we might as well start there.

After we get crawling, Marek Habersack of the Android team has suggested using [SimplePerf][SimplePerf] profiler. Eventually, we anticipate also needing to profile mono startup performance.

# Resources
* [SimplePerf][SimplePerf]: A tool which can help measuring native performance with very little overhead.

# Timeline
## January 14th
* Create repository
* Add Xamarin Forms and Android template projects
* Add logic to time difference between `onCreate` and `onResume`. 

[1]: https://programistologia.pl/2019/01/03/en-what-bothers-xamarin-developers-part-3/
[SimplePerf]: https://android.googlesource.com/platform/system/extras/+/master/simpleperf/doc/README.md