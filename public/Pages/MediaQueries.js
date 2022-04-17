import { fss } from "../fable_modules/Fss-lib.Fable.1.0.1/FssFable.fs.js";
import { Label_Label } from "../fable_modules/Fss-lib.Core.1.0.2/css/Content.fs.js";
import { unitHelpers_CssRuleWithLength__value_Z498FEB3B, unitHelpers_CssRuleWithAutoLength__value_Z498FEB3B } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Units.fs.js";
import { deg, px } from "../fable_modules/Fss-lib.Core.1.0.2/Functions.fs.js";
import { Height, Width } from "../fable_modules/Fss-lib.Core.1.0.2/css/ContentSize.fs.js";
import { ColorClass_Color__get_green, ColorClass_Color__get_red, ColorClass_Color__get_orangeRed, ColorClass_Color__get_pink, ColorClass_Color__get_blue } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Color.fs.js";
import { BackgroundColor } from "../fable_modules/Fss-lib.Core.1.0.2/css/Background.fs.js";
import { Color } from "../fable_modules/Fss-lib.Core.1.0.2/css/Color.fs.js";
import { empty, singleton, ofArray } from "../fable_modules/fable-library.3.7.9/List.js";
import { Media_Orientation, Media_Device, MediaClasses_Media__queryFor, Media_Feature, MediaClasses_Media__query } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Media.fs.js";
import { Media } from "../fable_modules/Fss-lib.Core.1.0.2/css/Media.fs.js";
import { MarginTop } from "../fable_modules/Fss-lib.Core.1.0.2/css/Margin.fs.js";
import { TransformClasses_TransformClass__rotate_CEE3389, TransformClasses_TransformClass__value_ZF56B0F4 } from "../fable_modules/Fss-lib.Core.1.0.2/Types/Transform.fs.js";
import { Transform } from "../fable_modules/Fss-lib.Core.1.0.2/css/Transform.fs.js";
import { FontSize } from "../fable_modules/Fss-lib.Core.1.0.2/css/Font.fs.js";
import { createElement } from "react";
import { Page } from "./Page.js";
import { Page as Page_1 } from "../Pages.js";

export function MediaQueries() {
    let arg10;
    const mediaQueryExamples = fss(ofArray([Label_Label("Media query examples"), unitHelpers_CssRuleWithAutoLength__value_Z498FEB3B(Width, px(200)), unitHelpers_CssRuleWithAutoLength__value_Z498FEB3B(Height, px(200)), ColorClass_Color__get_blue(BackgroundColor), (arg10 = ofArray([ColorClass_Color__get_pink(BackgroundColor), ColorClass_Color__get_orangeRed(Color)]), MediaClasses_Media__query(Media, singleton(new Media_Feature(19, px(700))), arg10)), MediaClasses_Media__queryFor(Media, new Media_Device(2), empty(), ofArray([unitHelpers_CssRuleWithAutoLength__value_Z498FEB3B(MarginTop, px(200)), TransformClasses_TransformClass__value_ZF56B0F4(Transform, singleton(TransformClasses_TransformClass__rotate_CEE3389(Transform, deg(45)))), ColorClass_Color__get_red(BackgroundColor)])), MediaClasses_Media__query(Media, singleton(new Media_Feature(27, new Media_Orientation(0))), ofArray([ColorClass_Color__get_green(Color), ColorClass_Color__get_orangeRed(BackgroundColor), unitHelpers_CssRuleWithLength__value_Z498FEB3B(FontSize, px(28))]))]));
    const styles = singleton(createElement("div", {
        className: mediaQueryExamples,
        children: "Changing width changes me",
    }));
    return createElement(Page, {
        page: new Page_1(11),
        styles: styles,
    });
}

export default (() => createElement(MediaQueries, null));

//# sourceMappingURL=MediaQueries.js.map
