
function HookBindings_makeDummyStateHook(value) {
    return {
        current: value,
        update(x) {
        },
        update(f) {
        },
    };
}

function HookBindings_makeDummyReducerHook(state) {
    return {
        current: state,
        update(msg) {
        },
    };
}

//# sourceMappingURL=Fable.React.Hooks.fs.js.map
