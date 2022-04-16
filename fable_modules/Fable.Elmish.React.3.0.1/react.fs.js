import * as react_dom from "react-dom";
import { ProgramModule_withSetState, ProgramModule_view } from "../Fable.Elmish.3.1.0/program.fs.js";
import { Common_lazyView2With } from "./common.fs.js";
import { uncurry } from "../fable-library.3.7.9/Util.js";

export function Program_Internal_withReactBatchedUsing(lazyView2With, placeholderId, program) {
    let lastRequest = void 0;
    const setState = (model, dispatch) => {
        if (lastRequest != null) {
            const r = lastRequest;
            window.cancelAnimationFrame(r);
        }
        lastRequest = window.requestAnimationFrame((_arg1) => {
            react_dom.render(lazyView2With((x) => ((y) => (x === y)), ProgramModule_view(program), model, dispatch), document.getElementById(placeholderId));
        });
    };
    return ProgramModule_withSetState(setState, program);
}

export function Program_Internal_withReactSynchronousUsing(lazyView2With, placeholderId, program) {
    const setState = (model, dispatch) => {
        react_dom.render(lazyView2With((x) => ((y) => (x === y)), ProgramModule_view(program), model, dispatch), document.getElementById(placeholderId));
    };
    return ProgramModule_withSetState(setState, program);
}

export function Program_Internal_withReactHydrateUsing(lazyView2With, placeholderId, program) {
    const setState = (model, dispatch) => {
        react_dom.hydrate(lazyView2With((x) => ((y) => (x === y)), ProgramModule_view(program), model, dispatch), document.getElementById(placeholderId));
    };
    return ProgramModule_withSetState(setState, program);
}

export function Program_withReactBatched(placeholderId, program) {
    return Program_Internal_withReactBatchedUsing((equal, view, state, dispatch) => Common_lazyView2With(uncurry(2, equal), uncurry(2, view), state, dispatch), placeholderId, program);
}

export function Program_withReactSynchronous(placeholderId, program) {
    return Program_Internal_withReactSynchronousUsing((equal, view, state, dispatch) => Common_lazyView2With(uncurry(2, equal), uncurry(2, view), state, dispatch), placeholderId, program);
}

export function Program_withReact(placeholderId, program) {
    return Program_Internal_withReactBatchedUsing((equal, view, state, dispatch) => Common_lazyView2With(uncurry(2, equal), uncurry(2, view), state, dispatch), placeholderId, program);
}

export function Program_withReactUnoptimized(placeholderId, program) {
    return Program_Internal_withReactSynchronousUsing((equal, view, state, dispatch) => Common_lazyView2With(uncurry(2, equal), uncurry(2, view), state, dispatch), placeholderId, program);
}

export function Program_withReactHydrate(placeholderId, program) {
    return Program_Internal_withReactHydrateUsing((equal, view, state, dispatch) => Common_lazyView2With(uncurry(2, equal), uncurry(2, view), state, dispatch), placeholderId, program);
}

//# sourceMappingURL=react.fs.js.map
