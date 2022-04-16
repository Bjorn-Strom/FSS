import { singleton, concat, map, empty, iterate } from "../fable-library.3.7.9/List.js";
import { singleton as singleton_1 } from "../fable-library.3.7.9/AsyncBuilder.js";
import { startImmediate, catchAsync } from "../fable-library.3.7.9/Async.js";
import { Timer_delay } from "./prelude.fs.js";

export function Cmd_exec(onError, dispatch, cmd) {
    iterate((call) => {
        try {
            call(dispatch);
        }
        catch (ex) {
            onError(ex);
        }
    }, cmd);
}

export function Cmd_none() {
    return empty();
}

export function Cmd_map(f, cmd) {
    return map((g) => ((arg_1) => {
        g((arg) => {
            arg_1(f(arg));
        });
    }), cmd);
}

export function Cmd_batch(cmds) {
    return concat(cmds);
}

export function Cmd_ofSub(sub) {
    return singleton(sub);
}

export function Cmd_OfFunc_either(task, arg, ofSuccess, ofError) {
    const bind = (dispatch) => {
        try {
            return dispatch(ofSuccess(task(arg)));
        }
        catch (x) {
            return dispatch(ofError(x));
        }
    };
    return singleton(bind);
}

export function Cmd_OfFunc_perform(task, arg, ofSuccess) {
    const bind = (dispatch) => {
        try {
            dispatch(ofSuccess(task(arg)));
        }
        catch (x) {
        }
    };
    return singleton(bind);
}

export function Cmd_OfFunc_attempt(task, arg, ofError) {
    const bind = (dispatch) => {
        try {
            task(arg);
        }
        catch (x) {
            dispatch(ofError(x));
        }
    };
    return singleton(bind);
}

export function Cmd_OfFunc_result(msg) {
    return singleton((dispatch) => {
        dispatch(msg);
    });
}

export function Cmd_OfAsyncWith_either(start, task, arg, ofSuccess, ofError) {
    const bind = (dispatch) => singleton_1.Delay(() => singleton_1.Bind(catchAsync(task(arg)), (_arg1) => {
        let x_1, x;
        const r = _arg1;
        dispatch((r.tag === 1) ? ((x_1 = r.fields[0], ofError(x_1))) : ((x = r.fields[0], ofSuccess(x))));
        return singleton_1.Zero();
    }));
    return singleton((arg_1) => {
        start(bind(arg_1));
    });
}

export function Cmd_OfAsyncWith_perform(start, task, arg, ofSuccess) {
    const bind = (dispatch) => singleton_1.Delay(() => singleton_1.Bind(catchAsync(task(arg)), (_arg1) => {
        const r = _arg1;
        if (r.tag === 0) {
            const x = r.fields[0];
            dispatch(ofSuccess(x));
            return singleton_1.Zero();
        }
        else {
            return singleton_1.Zero();
        }
    }));
    return singleton((arg_1) => {
        start(bind(arg_1));
    });
}

export function Cmd_OfAsyncWith_attempt(start, task, arg, ofError) {
    const bind = (dispatch) => singleton_1.Delay(() => singleton_1.Bind(catchAsync(task(arg)), (_arg1) => {
        const r = _arg1;
        if (r.tag === 1) {
            const x = r.fields[0];
            dispatch(ofError(x));
            return singleton_1.Zero();
        }
        else {
            return singleton_1.Zero();
        }
    }));
    return singleton((arg_1) => {
        start(bind(arg_1));
    });
}

export function Cmd_OfAsyncWith_result(start, task) {
    const bind = (dispatch) => singleton_1.Delay(() => singleton_1.Bind(task, (_arg1) => {
        const r = _arg1;
        dispatch(r);
        return singleton_1.Zero();
    }));
    return singleton((arg) => {
        start(bind(arg));
    });
}

export function Cmd_OfAsync_start(x) {
    Timer_delay(0, (_arg1) => {
        startImmediate(x);
    });
}

export function Cmd_OfPromise_either(task, arg, ofSuccess, ofError) {
    const bind = (dispatch) => {
        task(arg).then((arg_1) => dispatch(ofSuccess(arg_1))).catch((arg_3) => dispatch(ofError(arg_3)));
    };
    return singleton(bind);
}

export function Cmd_OfPromise_perform(task, arg, ofSuccess) {
    const bind = (dispatch) => {
        task(arg).then((arg_1) => dispatch(ofSuccess(arg_1)));
    };
    return singleton(bind);
}

export function Cmd_OfPromise_attempt(task, arg, ofError) {
    const bind = (dispatch) => {
        task(arg).catch((arg_2) => {
            dispatch(ofError(arg_2));
        });
    };
    return singleton(bind);
}

export function Cmd_OfPromise_result(task) {
    const bind = (dispatch) => {
        task.then(dispatch);
    };
    return singleton(bind);
}

export function Cmd_attemptFunc(task, arg, ofError) {
    return Cmd_OfFunc_attempt(task, arg, ofError);
}

//# sourceMappingURL=cmd.fs.js.map
