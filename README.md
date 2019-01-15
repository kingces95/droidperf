# Android Startup Performance
Xamarin management has identified Android startup performance as our top issue. 

"Startup performance" could mean different things to different people. For example, [this customer][1], blogs about both time to launch a minimal app (e.g. "Hello World") as well as an app with a moderate XAML homepage. The first would target mono/android stack while the latter would target XAML performance. Both could be targeted, but which first? 

To fix the right issue, we need to identify the customer(s) driving this priority to ensure we address their scenario. To do that we need to know what feedback, specifically, management is looking at. Bugs? Twitter? Blog posts? Sales and support? Telemetry? 

Which scenario, exactly, are we aiming at?

For now, just to get going, we assume we're minimizing cold/hot launch times of our template projects. That's the default experience we expose so we should track it regardless and compare it against out competitors default startup time.

At a minimum, our scenarios are: 
* The Xamarin Forms Android template project
* The Xamarin Android template project
* A native Java Android project

We'll instrument roughly for starters. For example, [this customer][1] simply used `Java.Lang.JavaSystem.CurrentTimeMillis()` to time the difference between `onCreate` and `onResume`. While that does not even capture the entire startup stack, it was sufficient to get this project off the ground. So we might as well start there. Just for fun, this [slow motion video][XFStartUpSlowMo] shows that number accounts for a bit less than half of startup time (So that's something!).

After we get crawling, Marek Habersack of the Android team has suggested using [SimplePerf][SimplePerf] profiler. 

# Resources
* [SimplePerf][SimplePerf]: A tool which can help measuring native performance with very little overhead.

# Timeline
## January 14th
* Create repository and this README.
* Add Xamarin Forms `XFStartUp` app which times `onCreate` to `onResume` and [video][XFStartUpSlowMo] which shows that accounts for a little less than half of startup time.

[1]: https://programistologia.pl/2019/01/03/en-what-bothers-xamarin-developers-part-3/
[SimplePerf]: https://android.googlesource.com/platform/system/extras/+/master/simpleperf/doc/README.md
[XFStartUpSlowMo]: https://m.youtube.com/watch?v=4d7FdyxY11w