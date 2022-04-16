import Timer from "../fable-library.3.7.9/Timer.js";
import { add } from "../fable-library.3.7.9/Observable.js";

export function Log_onError(text, ex) {
    console.error(text, ex);
}

export function Log_toConsole(text, o) {
    console.log(text, o);
}

export function Timer_delay(interval, callback) {
    let t;
    let returnVal = new Timer(interval);
    returnVal.AutoReset = false;
    t = returnVal;
    add(callback, t.Elapsed());
    t.Enabled = true;
    t.Start();
}

//# sourceMappingURL=prelude.fs.js.map
