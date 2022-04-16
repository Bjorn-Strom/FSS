import { some } from "../fable-library.3.7.9/Option.js";
import { create, isLeapYear } from "../fable-library.3.7.9/Date.js";
import { parse } from "../fable-library.3.7.9/Int32.js";
import { split, isNullOrWhiteSpace } from "../fable-library.3.7.9/String.js";
import { equalsWith } from "../fable-library.3.7.9/Array.js";
import react from "react";

export function DateParsing_$007CBetween$007C_$007C(x, y, input) {
    if ((input >= x) && (input <= y)) {
        return some(void 0);
    }
    else {
        return void 0;
    }
}

export function DateParsing_isLeapYear(year) {
    return isLeapYear(year);
}

export function DateParsing_$007CInt$007C_$007C(input) {
    try {
        return parse(input, 511, false, 32);
    }
    catch (matchValue) {
        return void 0;
    }
}

export function DateParsing_parse(input) {
    try {
        if (isNullOrWhiteSpace(input)) {
            return void 0;
        }
        else {
            const parts = split(input, ["-"], null, 0);
            let patternInput;
            let pattern_matching_result, month, year;
            if ((!equalsWith((x, y) => (x === y), parts, null)) && (parts.length === 2)) {
                const activePatternResult2807 = DateParsing_$007CInt$007C_$007C(parts[0]);
                if (activePatternResult2807 != null) {
                    const activePatternResult2808 = DateParsing_$007CInt$007C_$007C(parts[1]);
                    if (activePatternResult2808 != null) {
                        pattern_matching_result = 0;
                        month = activePatternResult2808;
                        year = activePatternResult2807;
                    }
                    else {
                        pattern_matching_result = 1;
                    }
                }
                else {
                    pattern_matching_result = 1;
                }
            }
            else {
                pattern_matching_result = 1;
            }
            switch (pattern_matching_result) {
                case 0: {
                    patternInput = [year, month, 1, 0, 0];
                    break;
                }
                case 1: {
                    let pattern_matching_result_1, day, month_1, year_1;
                    if ((!equalsWith((x_1, y_1) => (x_1 === y_1), parts, null)) && (parts.length === 3)) {
                        const activePatternResult2804 = DateParsing_$007CInt$007C_$007C(parts[0]);
                        if (activePatternResult2804 != null) {
                            const activePatternResult2805 = DateParsing_$007CInt$007C_$007C(parts[1]);
                            if (activePatternResult2805 != null) {
                                const activePatternResult2806 = DateParsing_$007CInt$007C_$007C(parts[2]);
                                if (activePatternResult2806 != null) {
                                    pattern_matching_result_1 = 0;
                                    day = activePatternResult2806;
                                    month_1 = activePatternResult2805;
                                    year_1 = activePatternResult2804;
                                }
                                else {
                                    pattern_matching_result_1 = 1;
                                }
                            }
                            else {
                                pattern_matching_result_1 = 1;
                            }
                        }
                        else {
                            pattern_matching_result_1 = 1;
                        }
                    }
                    else {
                        pattern_matching_result_1 = 1;
                    }
                    switch (pattern_matching_result_1) {
                        case 0: {
                            patternInput = [year_1, month_1, day, 0, 0];
                            break;
                        }
                        case 1: {
                            let pattern_matching_result_2, day_1, month_2, year_2;
                            if ((!equalsWith((x_2, y_2) => (x_2 === y_2), parts, null)) && (parts.length === 3)) {
                                const activePatternResult2802 = DateParsing_$007CInt$007C_$007C(parts[0]);
                                if (activePatternResult2802 != null) {
                                    const activePatternResult2803 = DateParsing_$007CInt$007C_$007C(parts[1]);
                                    if (activePatternResult2803 != null) {
                                        pattern_matching_result_2 = 0;
                                        day_1 = parts[2];
                                        month_2 = activePatternResult2803;
                                        year_2 = activePatternResult2802;
                                    }
                                    else {
                                        pattern_matching_result_2 = 1;
                                    }
                                }
                                else {
                                    pattern_matching_result_2 = 1;
                                }
                            }
                            else {
                                pattern_matching_result_2 = 1;
                            }
                            switch (pattern_matching_result_2) {
                                case 0: {
                                    if (day_1.indexOf("T") >= 0) {
                                        const matchValue = split(day_1, ["T"], null, 0);
                                        let pattern_matching_result_3, parsedDay, time;
                                        if ((!equalsWith((x_3, y_3) => (x_3 === y_3), matchValue, null)) && (matchValue.length === 2)) {
                                            const activePatternResult2801 = DateParsing_$007CInt$007C_$007C(matchValue[0]);
                                            if (activePatternResult2801 != null) {
                                                pattern_matching_result_3 = 0;
                                                parsedDay = activePatternResult2801;
                                                time = matchValue[1];
                                            }
                                            else {
                                                pattern_matching_result_3 = 1;
                                            }
                                        }
                                        else {
                                            pattern_matching_result_3 = 1;
                                        }
                                        switch (pattern_matching_result_3) {
                                            case 0: {
                                                const matchValue_1 = split(time, [":"], null, 0);
                                                let pattern_matching_result_4, hour, minute;
                                                if ((!equalsWith((x_4, y_4) => (x_4 === y_4), matchValue_1, null)) && (matchValue_1.length === 2)) {
                                                    const activePatternResult2799 = DateParsing_$007CInt$007C_$007C(matchValue_1[0]);
                                                    if (activePatternResult2799 != null) {
                                                        const activePatternResult2800 = DateParsing_$007CInt$007C_$007C(matchValue_1[1]);
                                                        if (activePatternResult2800 != null) {
                                                            pattern_matching_result_4 = 0;
                                                            hour = activePatternResult2799;
                                                            minute = activePatternResult2800;
                                                        }
                                                        else {
                                                            pattern_matching_result_4 = 1;
                                                        }
                                                    }
                                                    else {
                                                        pattern_matching_result_4 = 1;
                                                    }
                                                }
                                                else {
                                                    pattern_matching_result_4 = 1;
                                                }
                                                switch (pattern_matching_result_4) {
                                                    case 0: {
                                                        const matchValue_2 = [hour, minute];
                                                        let pattern_matching_result_5;
                                                        if (DateParsing_$007CBetween$007C_$007C(0, 59, matchValue_2[0]) != null) {
                                                            if (DateParsing_$007CBetween$007C_$007C(0, 59, matchValue_2[1]) != null) {
                                                                pattern_matching_result_5 = 0;
                                                            }
                                                            else {
                                                                pattern_matching_result_5 = 1;
                                                            }
                                                        }
                                                        else {
                                                            pattern_matching_result_5 = 1;
                                                        }
                                                        switch (pattern_matching_result_5) {
                                                            case 0: {
                                                                patternInput = [year_2, month_2, parsedDay, hour, minute];
                                                                break;
                                                            }
                                                            case 1: {
                                                                patternInput = [-1, 1, 1, 0, 0];
                                                                break;
                                                            }
                                                        }
                                                        break;
                                                    }
                                                    case 1: {
                                                        patternInput = [-1, 1, 1, 0, 0];
                                                        break;
                                                    }
                                                }
                                                break;
                                            }
                                            case 1: {
                                                patternInput = [-1, 1, 1, 0, 0];
                                                break;
                                            }
                                        }
                                    }
                                    else {
                                        patternInput = [-1, 1, 1, 0, 0];
                                    }
                                    break;
                                }
                                case 1: {
                                    patternInput = [-1, 1, 1, 0, 0];
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    break;
                }
            }
            const year_3 = patternInput[0] | 0;
            const month_3 = patternInput[1] | 0;
            const minute_1 = patternInput[4] | 0;
            const hour_1 = patternInput[3] | 0;
            const day_2 = patternInput[2] | 0;
            if (year_3 <= 0) {
                return void 0;
            }
            else {
                const matchValue_3 = [month_3, day_2];
                let pattern_matching_result_6;
                if (matchValue_3[0] === 2) {
                    if (DateParsing_$007CBetween$007C_$007C(1, 29, matchValue_3[1]) != null) {
                        if (DateParsing_isLeapYear(year_3)) {
                            pattern_matching_result_6 = 0;
                        }
                        else {
                            pattern_matching_result_6 = 1;
                        }
                    }
                    else {
                        pattern_matching_result_6 = 1;
                    }
                }
                else {
                    pattern_matching_result_6 = 1;
                }
                switch (pattern_matching_result_6) {
                    case 0: {
                        return create(year_3, month_3, day_2, hour_1, minute_1, 0);
                    }
                    case 1: {
                        let pattern_matching_result_7;
                        if (matchValue_3[0] === 2) {
                            if (DateParsing_$007CBetween$007C_$007C(1, 28, matchValue_3[1]) != null) {
                                if (!DateParsing_isLeapYear(year_3)) {
                                    pattern_matching_result_7 = 0;
                                }
                                else {
                                    pattern_matching_result_7 = 1;
                                }
                            }
                            else {
                                pattern_matching_result_7 = 1;
                            }
                        }
                        else {
                            pattern_matching_result_7 = 1;
                        }
                        switch (pattern_matching_result_7) {
                            case 0: {
                                return create(year_3, month_3, day_2, hour_1, minute_1, 0);
                            }
                            case 1: {
                                let pattern_matching_result_8;
                                if (matchValue_3[0] === 1) {
                                    if (DateParsing_$007CBetween$007C_$007C(1, 31, matchValue_3[1]) != null) {
                                        pattern_matching_result_8 = 0;
                                    }
                                    else {
                                        pattern_matching_result_8 = 1;
                                    }
                                }
                                else if (matchValue_3[0] === 3) {
                                    if (DateParsing_$007CBetween$007C_$007C(1, 31, matchValue_3[1]) != null) {
                                        pattern_matching_result_8 = 0;
                                    }
                                    else {
                                        pattern_matching_result_8 = 1;
                                    }
                                }
                                else if (matchValue_3[0] === 5) {
                                    if (DateParsing_$007CBetween$007C_$007C(1, 31, matchValue_3[1]) != null) {
                                        pattern_matching_result_8 = 0;
                                    }
                                    else {
                                        pattern_matching_result_8 = 1;
                                    }
                                }
                                else if (matchValue_3[0] === 7) {
                                    if (DateParsing_$007CBetween$007C_$007C(1, 31, matchValue_3[1]) != null) {
                                        pattern_matching_result_8 = 0;
                                    }
                                    else {
                                        pattern_matching_result_8 = 1;
                                    }
                                }
                                else if (matchValue_3[0] === 8) {
                                    if (DateParsing_$007CBetween$007C_$007C(1, 31, matchValue_3[1]) != null) {
                                        pattern_matching_result_8 = 0;
                                    }
                                    else {
                                        pattern_matching_result_8 = 1;
                                    }
                                }
                                else if (matchValue_3[0] === 10) {
                                    if (DateParsing_$007CBetween$007C_$007C(1, 31, matchValue_3[1]) != null) {
                                        pattern_matching_result_8 = 0;
                                    }
                                    else {
                                        pattern_matching_result_8 = 1;
                                    }
                                }
                                else if (matchValue_3[0] === 12) {
                                    if (DateParsing_$007CBetween$007C_$007C(1, 31, matchValue_3[1]) != null) {
                                        pattern_matching_result_8 = 0;
                                    }
                                    else {
                                        pattern_matching_result_8 = 1;
                                    }
                                }
                                else {
                                    pattern_matching_result_8 = 1;
                                }
                                switch (pattern_matching_result_8) {
                                    case 0: {
                                        return create(year_3, month_3, day_2, hour_1, minute_1, 0);
                                    }
                                    case 1: {
                                        let pattern_matching_result_9;
                                        if (matchValue_3[0] === 4) {
                                            if (DateParsing_$007CBetween$007C_$007C(1, 30, matchValue_3[1]) != null) {
                                                pattern_matching_result_9 = 0;
                                            }
                                            else {
                                                pattern_matching_result_9 = 1;
                                            }
                                        }
                                        else if (matchValue_3[0] === 6) {
                                            if (DateParsing_$007CBetween$007C_$007C(1, 30, matchValue_3[1]) != null) {
                                                pattern_matching_result_9 = 0;
                                            }
                                            else {
                                                pattern_matching_result_9 = 1;
                                            }
                                        }
                                        else if (matchValue_3[0] === 9) {
                                            if (DateParsing_$007CBetween$007C_$007C(1, 30, matchValue_3[1]) != null) {
                                                pattern_matching_result_9 = 0;
                                            }
                                            else {
                                                pattern_matching_result_9 = 1;
                                            }
                                        }
                                        else if (matchValue_3[0] === 11) {
                                            if (DateParsing_$007CBetween$007C_$007C(1, 30, matchValue_3[1]) != null) {
                                                pattern_matching_result_9 = 0;
                                            }
                                            else {
                                                pattern_matching_result_9 = 1;
                                            }
                                        }
                                        else {
                                            pattern_matching_result_9 = 1;
                                        }
                                        switch (pattern_matching_result_9) {
                                            case 0: {
                                                return create(year_3, month_3, day_2, hour_1, minute_1, 0);
                                            }
                                            case 1: {
                                                return void 0;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    catch (matchValue_4) {
        return void 0;
    }
}

export const Interop_reactApi = react;

//# sourceMappingURL=Interop.fs.js.map
