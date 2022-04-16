import { FSharpRef, Record } from "../fable-library.3.7.9/Types.js";
import { obj_type, record_type, lambda_type, class_type, unit_type } from "../fable-library.3.7.9/Reflection.js";
import { createAtom } from "../fable-library.3.7.9/Util.js";
import { value as value_1 } from "../fable-library.3.7.9/Option.js";
import { Component } from "react";
import { AppRegistry } from "react-native";
import { ProgramModule_withSetState, ProgramModule_view } from "../Fable.Elmish.3.1.0/program.fs.js";

export class Components_AppState extends Record {
    constructor(render, setState) {
        super();
        this.render = render;
        this.setState = setState;
    }
}

export function Components_AppState$reflection() {
    return record_type("Elmish.ReactNative.Components.AppState", [], Components_AppState, () => [["render", lambda_type(unit_type, class_type("Fable.React.ReactElement"))], ["setState", lambda_type(Components_AppState$reflection(), unit_type)]]);
}

export let Components_appState = createAtom(void 0);

export class Components_App extends Component {
    constructor(props) {
        super(props);
        let objectArg;
        const this$ = new FSharpRef(null);
        this$.contents = this;
        this["init@15-2"] = 1;
        if (Components_appState() != null) {
            const state = Components_appState();
            Components_appState(new Components_AppState(state.render, (objectArg = this$.contents, (arg00) => {
                this.state = arg00;
            })), true);
            this.state = state;
        }
        else {
            throw (new Error("was Elmish.ReactNative.Program.withReactNative called?"));
        }
    }
    componentDidMount() {
        const this$ = this;
        Components_appState(new Components_AppState(value_1(Components_appState()).render, (s) => {
            this$.setState((_arg2, _arg1) => s);
        }), true);
    }
    componentWillUnmount() {
        let inputRecord;
        const this$ = this;
        Components_appState((inputRecord = value_1(Components_appState()), new Components_AppState((this$.state).render, (value) => {
        })), true);
    }
    render() {
        const this$ = this;
        return (this$.state).render();
    }
}

export function Components_App$reflection() {
    return class_type("Elmish.ReactNative.Components.App", void 0, Components_App, class_type("Fable.React.Component`2", [obj_type, Components_AppState$reflection()], Component));
}

export function Components_App_$ctor_4E60E31B(props) {
    return new Components_App(props);
}

export function Program_withReactNative(appKey, program) {
    AppRegistry.registerComponent(appKey, () => Components_App);
    const setState = (m, d) => {
        if (Components_appState() != null) {
            const state = Components_appState();
            state.setState(new Components_AppState(() => ProgramModule_view(program)(m)(d), state.setState));
        }
        else {
            Components_appState(new Components_AppState(() => ProgramModule_view(program)(m)(d), (value) => {
            }), true);
        }
    };
    return ProgramModule_withSetState(setState, program);
}

//# sourceMappingURL=react-native.fs.js.map
