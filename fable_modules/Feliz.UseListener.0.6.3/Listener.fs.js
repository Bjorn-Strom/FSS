import { bind, map } from "../fable-library.3.7.9/Option.js";

export const Impl_allowsPassiveEvents = (() => {
    let passive = false;
    try {
        if ((typeof window !== 'undefined') && (typeof window.addEventListener === 'function')) {
            const options = {
                passive: true,
            };
            window.addEventListener("testPassiveEventSupport", (value) => {
            }, options);
            window.removeEventListener("testPassiveEventSupport", (value_1) => {
            });
        }
    }
    catch (matchValue) {
    }
    return passive;
})();

export const Impl_defaultPassive = {
    passive: true,
};

export function Impl_adjustPassive(maybeOptions) {
    return map((options) => {
        if (options.passive && (!Impl_allowsPassiveEvents)) {
            return {
                capture: options.capture,
                once: options.once,
                passive: false,
            };
        }
        else {
            return options;
        }
    }, maybeOptions);
}

export function Impl_createRemoveOptions(maybeOptions) {
    return bind((options) => {
        if (options.capture) {
            return {
                capture: true,
            };
        }
        else {
            return void 0;
        }
    }, maybeOptions);
}

//# sourceMappingURL=Listener.fs.js.map
