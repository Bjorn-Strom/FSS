import { Exception } from "./Types.js";
import { class_type } from "./Reflection.js";

export class SystemException extends Exception {
    constructor() {
        super();
    }
}

export function SystemException$reflection() {
    return class_type("System.SystemException", void 0, SystemException, class_type("System.Exception"));
}

export function SystemException_$ctor() {
    return new SystemException();
}

export class TimeoutException extends SystemException {
    constructor() {
        super();
    }
}

export function TimeoutException$reflection() {
    return class_type("System.TimeoutException", void 0, TimeoutException, SystemException$reflection());
}

export function TimeoutException_$ctor() {
    return new TimeoutException();
}

