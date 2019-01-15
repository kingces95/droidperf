# Android Startup Performance
Xamarin management has identified Android startup performance as our top issue. 

What, exactly constitutes "Startup performance"? It could mean different things to different people. For example, [this customer][1] blogs about (1) time to launch a minimal app (e.g. "Hello World") and (2) an app with a bit of XAML. The first would target mono/android stack while the latter would target XAML performance. Both could be targeted, but which first? 

To fix the right issue, the top issue, and to properly measure our progress we need to know the specific feedback management is looking at. Bugs? Twitter? Blog posts? Sales and support? Telemetry? 

Which scenario, exactly, are we optimizing? This is step 0.
# Blog
_January 14th, 2019_

Just to get going, let's assume we're minimizing hot launch times of our template projects. That's the default experience we expose so we should track it regardless. We should also compare it against our competitors default startup times.

Our scenarios are: 
* The Xamarin Forms Android template project
* The Xamarin Android template project
* A native Java Android project

[This customer][1] simply used `Java.Lang.JavaSystem.CurrentTimeMillis()` to time the difference between `onCreate` and `onResume`. That was enough to kick off this project, so we might as well start there! Because that will not capture the entire startup stack we, just for fun, took slow motion video capture of [Xamarin.Android][XAStartUp] and [Xamarin.Forms][XFStartUp] starting up. With those numbers we can compare:
* WC: Wall Clock
* C#: `onResume` - `onCreate`, roughly managed code
* Mono: WC - C#, roughly unmanaged code
* XF vs XA (raw): Xamarin Forms vs Xamarin Android startup
* XF vs XA (adj): XF vs XA adjusted by mono startup time which should (arguably) be the same. This type of adjustment is arguable because Mono might take more time to load all our XF assemblies. And this is all super rough and just for fun! So big grain of salt people!

|App|WC|%|C#|%|Mono|%
|---:|---:|---:|---:|---:|---:|---:|
|XF|2150ms| |875ms| 40%|1275ms| 60%|
|XA|1200ms| |113ms| 10%|1087ms| 90%|
|XF vs XA (adj)|+760ms| +65%|+612ms| +6x|0| 0%|
|XF vs XA (raw)|+950ms| +80%|+762ms| +8x|+188| -20%|


So, at first glance, seems XF template project has some explaining to do! And XA looks pretty slim compared to the mono startup time. 

After we get crawling, Marek Habersack of the Android team has suggested using [SimplePerf][SimplePerf] profiler. 

# Resources
* [SimplePerf][SimplePerf]: A tool which can help measuring native performance with very little overhead.

# Timeline
In reverse chronological order.
## Now
* Rolled up results into README.
* Captured slow motion video of [XFStartUp][XFStartUp] and [XAStartUp][XAStartup] which shows, roughly, the mono startup time.
* Add Xamarin Forms `XFStartUp` app and Xamarin Android `XAStartUp` app from the template projects modified slightly to display the duration between `onCreate` and `onResume`.
* Create repository and this README.
## January


[1]: https://programistologia.pl/2019/01/03/en-what-bothers-xamarin-developers-part-3/
[SimplePerf]: https://android.googlesource.com/platform/system/extras/+/master/simpleperf/doc/README.md
[XAStartUp]: https://m.youtube.com/watch?v=G9ylTGtsy5s
[XFStartUp]: https://www.youtube.com/watch?v=cKz8KDs1NAA