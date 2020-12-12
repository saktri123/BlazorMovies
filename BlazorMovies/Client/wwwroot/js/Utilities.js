function CustomLog(message) {
    console.log("Utilites - " + message);
};

function DotNetStaticInvoke() {
    DotNet.invokeMethodAsync("BlazorMovies.Client", "GetCurrentCount").
        then(x => {
            console.log("Counter from JS" + x);
        });
}

function DotNetInstanceInvoke(DotNetHelper) {
    DotNetHelper.invokeMethodAsync("IncrementCount")
}