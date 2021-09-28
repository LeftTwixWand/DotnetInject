# DotnetInject
Source generator for simplifying dependency injection with Microsoft.Extensions.DependencyInjection


We are all used to injecting a bunch of dependencies into a class and initializing them in the constructor.<br>
The output is usually something like this:<br><br>
![alt text](https://image.prntscr.com/image/fQu_o7pGRd2iVGxsoldzZw.png)

It's time to end it!<br>
I present to your attention a new, convenient and elegant way:<br><br>
![alt text](https://image.prntscr.com/image/pKnVAJnYSLqlGTy5ZgfmYw.png)

But what if you are too lazy to specify the Inject attribute for each dependency?<br>
Not a problem, you can specify the Inject attribute for the entire class. <br> In this case, all private fields with the readonly modifier will be taken:<br><br>
![alt text](https://image.prntscr.com/image/WH_VuE70SxGT-xqSvu_vhg.png)

Fine. But what if there is a field that is not needed for injection? <br>
Specify the InjectIgnore attribute for such a field: <br> <br>
![alt text](https://image.prntscr.com/image/I1eSHDglSJewrUg7xlrjYw.png)
