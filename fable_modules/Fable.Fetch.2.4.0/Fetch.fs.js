import { Union } from "../fable-library.3.7.9/Types.js";
import { bool_type, class_type, union_type, obj_type, int32_type, string_type } from "../fable-library.3.7.9/Reflection.js";
import { int32ToString } from "../fable-library.3.7.9/Util.js";
import { keyValueList } from "../fable-library.3.7.9/MapUtil.js";
import { result } from "../Fable.Promise.2.2.2/Promise.fs.js";
import { singleton } from "../fable-library.3.7.9/List.js";

export class Types_HttpRequestHeaders extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Accept", "Accept-Charset", "Accept-Encoding", "Accept-Language", "Accept-Datetime", "Authorization", "Cache-Control", "Connection", "Cookie", "Content-Length", "Content-MD5", "Content-Type", "Date", "Expect", "Forwarded", "From", "Host", "If-Match", "If-Modified-Since", "If-None-Match", "If-Range", "If-Unmodified-Since", "Max-Forwards", "Origin", "Pragma", "Proxy-Authorization", "Range", "Referer", "SOAPAction", "TE", "User-Agent", "Upgrade", "Via", "Warning", "X-Requested-With", "DNT", "X-Forwarded-For", "X-Forwarded-Host", "X-Forwarded-Proto", "Front-End-Https", "X-Http-Method-Override", "X-ATT-DeviceId", "X-Wap-Profile", "Proxy-Connection", "X-UIDH", "X-Csrf-Token", "Custom"];
    }
}

export function Types_HttpRequestHeaders$reflection() {
    return union_type("Fetch.Types.HttpRequestHeaders", [], Types_HttpRequestHeaders, () => [[["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", int32_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["key", string_type], ["value", obj_type]]]);
}

export class Types_RequestProperties extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Method", "Headers", "Body", "Mode", "Credentials", "Cache", "Redirect", "Referrer", "ReferrerPolicy", "Integrity", "KeepAlive", "Signal"];
    }
}

export function Types_RequestProperties$reflection() {
    return union_type("Fetch.Types.RequestProperties", [], Types_RequestProperties, () => [[["Item", string_type]], [["Item", class_type("Fetch.Types.IHttpRequestHeaders")]], [["Item", obj_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", string_type]], [["Item", bool_type]], [["Item", class_type("Fetch.Types.AbortSignal")]]]);
}

function errorString(response) {
    return (((int32ToString(response.status) + " ") + (response.statusText)) + " for URL ") + (response.url);
}

export function fetch$(url, init) {
    const pr = fetch(url, keyValueList(init, 1));
    return pr.then((response) => {
        if (response.ok) {
            return response;
        }
        else {
            const message = errorString(response);
            throw (new Error(message));
        }
    });
}

export function fetchUnsafe(url, init) {
    return fetch(url, keyValueList(init, 1));
}

export function tryFetch(url, init) {
    return result(fetch$(url, init));
}

export function tryOptionsRequest(url) {
    return result(fetch$(url, singleton(new Types_RequestProperties(0, "OPTIONS"))));
}

//# sourceMappingURL=Fetch.fs.js.map
