import { Record } from "../fable-library.3.7.9/Types.js";
import { obj_type, record_type, bool_type, lambda_type, class_type, unit_type } from "../fable-library.3.7.9/Reflection.js";
import { Component } from "react";
import * as react from "react";
import { equalArrays, equals } from "../fable-library.3.7.9/Util.js";

export class LazyProps$1 extends Record {
    constructor(model, render, equal) {
        super();
        this.model = model;
        this.render = render;
        this.equal = equal;
    }
}

export function LazyProps$1$reflection(gen0) {
    return record_type("Elmish.React.LazyProps`1", [gen0], LazyProps$1, () => [["model", gen0], ["render", lambda_type(unit_type, class_type("Fable.React.ReactElement"))], ["equal", lambda_type(gen0, lambda_type(gen0, bool_type))]]);
}

export class Components_LazyView$1 extends Component {
    constructor(props) {
        super(props);
    }
    shouldComponentUpdate(nextProps, _nextState) {
        const this$ = this;
        return !(this$.props).equal((this$.props).model, nextProps.model);
    }
    render() {
        const this$ = this;
        return (this$.props).render();
    }
}

export function Components_LazyView$1$reflection(gen0) {
    return class_type("Elmish.React.Components.LazyView`1", [gen0], Components_LazyView$1, class_type("Fable.React.Component`2", [LazyProps$1$reflection(gen0), obj_type], Component));
}

export function Components_LazyView$1_$ctor_Z7829D94B(props) {
    return new Components_LazyView$1(props);
}

export function Common_lazyViewWith(equal, view, state) {
    const props = new LazyProps$1(state, () => view(state), equal);
    return react.createElement(Components_LazyView$1, props);
}

export function Common_lazyView2With(equal, view, state, dispatch) {
    const props = new LazyProps$1(state, () => view(state, dispatch), equal);
    return react.createElement(Components_LazyView$1, props);
}

export function Common_lazyView3With(equal, view, state1, state2, dispatch) {
    const props = new LazyProps$1([state1, state2], () => view(state1, state2, dispatch), equal);
    return react.createElement(Components_LazyView$1, props);
}

export function Common_lazyView(view) {
    return (state) => Common_lazyViewWith(equals, view, state);
}

export function Common_lazyView2(view) {
    return (state) => ((dispatch) => Common_lazyView2With(equals, view, state, dispatch));
}

export function Common_lazyView3(view) {
    return (state1) => ((state2) => ((dispatch) => Common_lazyView3With(equalArrays, view, state1, state2, dispatch)));
}

//# sourceMappingURL=common.fs.js.map
