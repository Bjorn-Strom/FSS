import { Record } from "../fable-library.3.7.9/Types.js";
import { record_type, class_type, string_type, tuple_type, list_type, lambda_type, unit_type } from "../fable-library.3.7.9/Reflection.js";
import { Cmd_exec, Cmd_batch, Cmd_none } from "./cmd.fs.js";
import { curry, partialApply, uncurry } from "../fable-library.3.7.9/Util.js";
import { Log_toConsole, Log_onError } from "./prelude.fs.js";
import { ofArray } from "../fable-library.3.7.9/List.js";
import { RingBuffer$1__Pop, RingBuffer$1__Push_2B595, RingBuffer$1_$ctor_Z524259A4 } from "./ring.fs.js";
import { value as value_1, some } from "../fable-library.3.7.9/Option.js";
import { printf, toText } from "../fable-library.3.7.9/String.js";

export class Program$4 extends Record {
    constructor(init, update, subscribe, view, setState, onError, syncDispatch) {
        super();
        this.init = init;
        this.update = update;
        this.subscribe = subscribe;
        this.view = view;
        this.setState = setState;
        this.onError = onError;
        this.syncDispatch = syncDispatch;
    }
}

export function Program$4$reflection(gen0, gen1, gen2, gen3) {
    return record_type("Elmish.Program`4", [gen0, gen1, gen2, gen3], Program$4, () => [["init", lambda_type(gen0, tuple_type(gen1, list_type(lambda_type(lambda_type(gen2, unit_type), unit_type))))], ["update", lambda_type(gen2, lambda_type(gen1, tuple_type(gen1, list_type(lambda_type(lambda_type(gen2, unit_type), unit_type)))))], ["subscribe", lambda_type(gen1, list_type(lambda_type(lambda_type(gen2, unit_type), unit_type)))], ["view", lambda_type(gen1, lambda_type(lambda_type(gen2, unit_type), gen3))], ["setState", lambda_type(gen1, lambda_type(lambda_type(gen2, unit_type), unit_type))], ["onError", lambda_type(tuple_type(string_type, class_type("System.Exception")), unit_type)], ["syncDispatch", lambda_type(lambda_type(gen2, unit_type), lambda_type(gen2, unit_type))]]);
}

export function ProgramModule_mkProgram(init, update, view) {
    return new Program$4(init, update, (_arg1) => Cmd_none(), view, uncurry(2, (model) => {
        const f1 = partialApply(1, view, [model]);
        return (arg) => {
            f1(arg);
        };
    }), (tupledArg) => {
        Log_onError(tupledArg[0], tupledArg[1]);
    }, uncurry(2, (x) => x));
}

export function ProgramModule_mkSimple(init, update, view) {
    return new Program$4((arg) => [init(arg), Cmd_none()], uncurry(2, (msg) => {
        const f1_1 = partialApply(1, update, [msg]);
        return (arg_1) => [f1_1(arg_1), Cmd_none()];
    }), (_arg1) => Cmd_none(), view, uncurry(2, (model) => {
        const f1_2 = partialApply(1, view, [model]);
        return (arg_2) => {
            f1_2(arg_2);
        };
    }), (tupledArg) => {
        Log_onError(tupledArg[0], tupledArg[1]);
    }, uncurry(2, (x) => x));
}

export function ProgramModule_withSubscription(subscribe, program) {
    const sub = (model) => Cmd_batch(ofArray([program.subscribe(model), subscribe(model)]));
    return new Program$4(program.init, program.update, sub, program.view, program.setState, program.onError, program.syncDispatch);
}

export function ProgramModule_withConsoleTrace(program) {
    const traceInit = (arg) => {
        const patternInput = program.init(arg);
        const initModel = patternInput[0];
        const cmd = patternInput[1];
        Log_toConsole("Initial state:", initModel);
        return [initModel, cmd];
    };
    const traceUpdate = (msg, model) => {
        Log_toConsole("New message:", msg);
        const patternInput_1 = program.update(msg, model);
        const newModel = patternInput_1[0];
        const cmd_1 = patternInput_1[1];
        Log_toConsole("Updated state:", newModel);
        return [newModel, cmd_1];
    };
    return new Program$4(traceInit, traceUpdate, program.subscribe, program.view, program.setState, program.onError, program.syncDispatch);
}

export function ProgramModule_withTrace(trace, program) {
    const update = (msg, model) => {
        const patternInput = program.update(msg, model);
        const state = patternInput[0];
        const cmd = patternInput[1];
        trace(msg, state);
        return [state, cmd];
    };
    return new Program$4(program.init, update, program.subscribe, program.view, program.setState, program.onError, program.syncDispatch);
}

export function ProgramModule_withErrorHandler(onError, program) {
    return new Program$4(program.init, program.update, program.subscribe, program.view, program.setState, onError, program.syncDispatch);
}

export function ProgramModule_mapErrorHandler(map, program) {
    return new Program$4(program.init, program.update, program.subscribe, program.view, program.setState, partialApply(1, map, [program.onError]), program.syncDispatch);
}

export function ProgramModule_onError(program) {
    return program.onError;
}

export function ProgramModule_withSetState(setState, program) {
    return new Program$4(program.init, program.update, program.subscribe, program.view, setState, program.onError, program.syncDispatch);
}

export function ProgramModule_setState(program) {
    return curry(2, program.setState);
}

export function ProgramModule_view(program) {
    return curry(2, program.view);
}

export function ProgramModule_withSyncDispatch(syncDispatch, program) {
    return new Program$4(program.init, program.update, program.subscribe, program.view, program.setState, program.onError, syncDispatch);
}

export function ProgramModule_map(mapInit, mapUpdate, mapView, mapSetState, mapSubscribe, program) {
    const init = partialApply(1, mapInit, [program.init]);
    const update = partialApply(2, mapUpdate, [curry(2, program.update)]);
    const view = partialApply(2, mapView, [curry(2, program.view)]);
    const setState = partialApply(2, mapSetState, [curry(2, program.setState)]);
    return new Program$4(init, uncurry(2, update), partialApply(1, mapSubscribe, [program.subscribe]), uncurry(2, view), uncurry(2, setState), program.onError, uncurry(2, (x) => x));
}

export function ProgramModule_runWith(arg, program) {
    const patternInput = program.init(arg);
    const model = patternInput[0];
    const cmd = patternInput[1];
    const rb = RingBuffer$1_$ctor_Z524259A4(10);
    let reentered = false;
    let state = model;
    const dispatch = (msg) => {
        if (reentered) {
            RingBuffer$1__Push_2B595(rb, msg);
        }
        else {
            reentered = true;
            let nextMsg = some(msg);
            while (nextMsg != null) {
                const msg_1 = value_1(nextMsg);
                try {
                    const patternInput_1 = program.update(msg_1, state);
                    const model$0027 = patternInput_1[0];
                    const cmd$0027 = patternInput_1[1];
                    program.setState(model$0027, syncDispatch);
                    Cmd_exec((ex) => {
                        program.onError([toText(printf("Error in command while handling: %A"))(msg_1), ex]);
                    }, syncDispatch, cmd$0027);
                    state = model$0027;
                }
                catch (ex_1) {
                    program.onError([toText(printf("Unable to process the message: %A"))(msg_1), ex_1]);
                }
                nextMsg = RingBuffer$1__Pop(rb);
            }
            reentered = false;
        }
    };
    const syncDispatch = partialApply(1, program.syncDispatch, [dispatch]);
    program.setState(model, syncDispatch);
    let sub;
    try {
        sub = program.subscribe(model);
    }
    catch (ex_2) {
        program.onError(["Unable to subscribe:", ex_2]);
        sub = Cmd_none();
    }
    Cmd_exec((ex_3) => {
        program.onError(["Error intitializing:", ex_3]);
    }, syncDispatch, Cmd_batch(ofArray([sub, cmd])));
}

export function ProgramModule_run(program) {
    ProgramModule_runWith(void 0, program);
}

//# sourceMappingURL=program.fs.js.map
