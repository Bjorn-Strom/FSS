namespace Fss

open Utilities.Helpers

module Property =
    type Property =
        | AlignContent
        | AlignItems
        | AlignSelf
        | All
        | Animation                     
        | AnimationDelay                
        | AnimationDirection            
        | AnimationDuration             
        | AnimationFillMode             
        | AnimationIterationCount       
        | AnimationName                 
        | AnimationPlayState            
        | AnimationTimingFunction       
        | BackfaceVisibility
        | BackgroundAttachment
        | BackgroundBlendMode
        | BackgroundClip
        | BackgroundColor               
        | BackgroundImage
        | BackgroundOrigin
        | BackgroundPosition
        | BackgroundRepeat
        | BackgroundSize
        | Background
        | Bleed
        | BorderBottomColor             
        | BorderBottomLeftRadius        
        | BorderBottomRightRadius       
        | BorderBottomStyle
        | BorderBottomWidth             
        | BorderBottom
        | BorderCollapse
        | BorderColor                   
        | BorderImage
        | BorderImageOutset
        | BorderImageRepeat
        | BorderImageSource
        | BorderImageSlice
        | BorderImageWidth
        | BorderLeftColor               
        | BorderLeftStyle
        | BorderLeftWidth               
        | BorderLeft
        | BorderRadius                  
        | BorderRightColor              
        | BorderRightStyle
        | BorderRightWidth              
        | BorderRight
        | BorderSpacing
        | BorderStyle                    
        | BorderTopColor                 
        | BorderTopLeftRadius            
        | BorderTopRightRadius           
        | BorderTopStyle
        | BorderTopWidth                 
        | BorderTop
        | BorderWidth                    
        | Border                         
        | Bottom
        | BoxDecorationBreak
        | BoxShadow
        | BoxSizing
        | BreakAfter
        | BreakBefore
        | BreakInside
        | CaptionSide
        | CaretColor
        | Clear
        | Clip
        | Color                             
        | Columns
        | ColumnCount
        | ColumnFill
        | ColumnGap
        | ColumnRule
        | ColumnRuleColor
        | ColumnRuleStyle
        | ColumnRuleWidth
        | ColumnSpan
        | ColumnWidth
        | Content
        | CounterIncrement
        | CounterReset
        | CueAfter
        | CueBefore
        | Cue
        | Cursor
        | Direction
        | Display
        | Elevation
        | EmptyCells
        | Filter
        | Flex
        | FlexBasis
        | FlexDirection
        | FontFeatureSettings
        | FlexFlow
        | FlexGrow
        | FlexShrink
        | FlexWrap
        | Float
        | FontFamily
        | FontKerning
        | FontLanguageOverride
        | FontSizeAdjust
        | FontSize                   
        | FontStretch
        | FontStyle
        | FontDisplay
        | FontSynthesis
        | FontVariant
        | FontVariantAlternates
        | FontVariantCaps
        | FontVariantEastAsian
        | FontVariantLigatures
        | FontVariantNumeric
        | FontVariantPosition
        | FontWeight
        | Font
        | GridArea
        | GridAutoColumns
        | GridAutoFlow
        | GridAutoRows
        | GridColumnEnd
        | GridColumnGap
        | GridColumnStart
        | GridColumn
        | GridGap
        | GridRowEnd
        | GridRowGap
        | GridRowStart
        | GridRow
        | GridTemplateAreas
        | GridTemplateColumns
        | GridTemplateRows
        | GridTemplate
        | Grid
        | HangingPunctuation
        | Height
        | Hyphens
        | Isolation
        | JustifyContent
        | JustifyItems
        | JustifySelf
        | Label
        | Left
        | LetterSpacing
        | LineBreak
        | LineHeight
        | ListStyleImage
        | ListStylePosition
        | ListStyleType
        | ListStyle
        | MarginBottom
        | MarginLeft
        | MarginRight
        | MarginTop
        | Margin
        | MarkerOffset
        | Marks
        | MaxHeight
        | MaxWidth
        | MinHeight
        | MinWidth
        | MixBlendMode
        | NavUp
        | NavDown
        | NavLeft
        | NavRight
        | Opacity
        | Order
        | Orphans
        | OutlineColor
        | OutlineOffset
        | OutlineStyle
        | OutlineWidth
        | Outline
        | Overflow
        | OverflowWrap
        | OverflowX
        | OverflowY
        | PaddingBottom
        | PaddingLeft
        | PaddingRight
        | PaddingTop
        | Padding
        | PageBreakAfter
        | PageBreakBefore
        | PageBreakInside
        | Page
        | PauseAfter
        | PauseBefore
        | Pause
        | Perspective
        | PerspectiveOrigin
        | PitchRange
        | Pitch
        | PlaceContent
        | PlaceItems
        | PlaceSelf
        | PlayDuring
        | Position
        | Quotes
        | Resize
        | RestAfter
        | RestBefore
        | Rest
        | Richness
        | Right
        | Size
        | SpeakHeader
        | SpeakNumeral
        | SpeakPunctuation
        | Speak
        | SpeechRate
        | Stress
        | TabSize
        | TableLayout
        | TextAlign
        | TextAlignlast
        | TextDecoration
        | TextDecorationColor
        | TextDecorationLine
        | TextDecorationSkip
        | TextDecorationStyle
        | TextIndent
        | TextOverflow
        | TextShadow
        | TextTransform
        | TextUnderlinePosition
        | Top
        | Transform                      
        | TransformOrigin
        | TransformStyle
        | Transition                     
        | TransitionDelay
        | TransitionDuration
        | TransitionProperty
        | TransitionTimingFunction
        | UnicodeBidi
        | VerticalAlign
        | Visibility
        | VoiceBalance
        | VoiceDuration
        | VoiceFamily
        | VoicePitch
        | VoiceRange
        | VoiceRate
        | VoiceStress
        | VoiceVolume
        | Volume
        | WhiteSpace
        | Widows
        | Width
        | WillChange
        | WordBreak
        | WordSpacing
        | WordWrap
        | ZIndex

        | Hover

    let value (v: Property): string = duToCamel v 

    let propertyToKebabCase (property: Property): string =
        property
        |> value
        |> pascalToKebabCase

    let alignContent = AlignContent
    let alignItems = AlignItems
    let alignSelf = AlignSelf
    let all = All
    let animation = Animation
    let animationDelay = AnimationDelay
    let animationDirection = AnimationDirection
    let animationDuration = AnimationDuration
    let animationFillMode = AnimationFillMode
    let animationIterationCount = AnimationIterationCount
    let animationName = AnimationName
    let animationPlayState = AnimationPlayState
    let animationTimingFunction = AnimationTimingFunction
    let backfaceVisibility = BackfaceVisibility
    let backgroundAttachment = BackgroundAttachment
    let backgroundBlendMode = BackgroundBlendMode
    let backgroundClip = BackgroundClip
    let backgroundColor = BackgroundColor
    let backgroundImage = BackgroundImage
    let backgroundOrigin = BackgroundOrigin
    let backgroundPosition = BackgroundPosition
    let backgroundRepeat = BackgroundRepeat
    let backgroundSize = BackgroundSize
    let background = Background
    let bleed = Bleed
    let borderBottomColor = BorderBottomColor
    let borderBottomLeftRadius = BorderBottomLeftRadius
    let borderBottomRightRadius = BorderBottomRightRadius
    let borderBottomStyle = BorderBottomStyle
    let borderBottomWidth = BorderBottomWidth
    let borderBottom = BorderBottom
    let borderCollapse = BorderCollapse
    let borderColor = BorderColor
    let borderImage = BorderImage
    let borderImageOutset = BorderImageOutset
    let borderImageRepeat = BorderImageRepeat
    let borderImageSource = BorderImageSource
    let borderImageSlice = BorderImageSlice
    let borderImageWidth = BorderImageWidth
    let borderLeftColor = BorderLeftColor
    let borderLeftStyle = BorderLeftStyle
    let borderLeftWidth = BorderLeftWidth
    let borderLeft = BorderLeft
    let borderRadius = BorderRadius
    let borderRightColor = BorderRightColor
    let borderRightStyle = BorderRightStyle
    let borderRightWidth = BorderRightWidth
    let borderRight = BorderRight
    let borderSpacing = BorderSpacing
    let borderStyle = BorderStyle
    let borderTopColor = BorderTopColor
    let borderTopLeftRadius = BorderTopLeftRadius
    let borderTopRightRadius = BorderTopRightRadius
    let borderTopStyle = BorderTopStyle
    let borderTopWidth = BorderTopWidth
    let borderTop = BorderTop
    let borderWidth = BorderWidth
    let border = Border
    let bottom = Bottom
    let boxDecorationBreak = BoxDecorationBreak
    let boxShadow = BoxShadow
    let boxSizing = BoxSizing
    let breakAfter = BreakAfter
    let breakBefore = BreakBefore
    let breakInside = BreakInside
    let captionSide = CaptionSide
    let caretColor = CaretColor
    let clear = Clear
    let clip = Clip
    let color = Color
    let columns = Columns
    let columnCount = ColumnCount
    let columnFill = ColumnFill
    let columnGap = ColumnGap
    let columnRule = ColumnRule 
    let columnRuleColor = ColumnRuleColor 
    let columnRuleStyle = ColumnRuleStyle
    let columnRuleWidth = ColumnRuleWidth 
    let columnSpan = ColumnSpan
    let columnWidth = ColumnWidth
    let content = Content
    let counterIncrement = CounterIncrement
    let counterReset = CounterReset
    let cueAfter = CueAfter
    let cueBefore = CueBefore
    let cue = Cue
    let cursor = Cursor
    let direction = Direction
    let display = Display
    let elevation = Elevation
    let emptyCells = EmptyCells
    let filter = Filter
    let flex = Flex
    let flexBasis = FlexBasis
    let flexDirection = FlexDirection
    let fontFeatureSettings = FontFeatureSettings
    let flexFlow = FlexFlow
    let flexGrow = FlexGrow
    let flexShrink = FlexShrink
    let flexWrap = FlexWrap
    let float = Float
    let fontFamily = FontFamily
    let fontKerning = FontKerning
    let fontLanguageOverride = FontLanguageOverride
    let fontSizeAdjust = FontSizeAdjust
    let fontSize = FontSize                  
    let fontStretch = FontStretch
    let fontStyle = FontStyle
    let fontDisplay = FontDisplay
    let fontSynthesis = FontSynthesis
    let fontVariant = FontVariant
    let fontVariantAlternates = FontVariantAlternates
    let fontVariantCaps = FontVariantCaps
    let fontVariantEastAsian = FontVariantEastAsian
    let fontVariantLigatures = FontVariantLigatures
    let fontVariantNumeric = FontVariantNumeric
    let fontVariantPosition = FontVariantPosition
    let fontWeight = FontWeight
    let font = Font
    let gridArea = GridArea
    let gridAutoColumns = GridAutoColumns
    let gridAutoFlow = GridAutoFlow
    let gridAutoRows = GridAutoRows
    let gridColumnEnd = GridColumnEnd
    let gridColumnGap = GridColumnGap
    let gridColumnStart = GridColumnStart
    let gridColumn = GridColumn
    let gridGap = GridGap
    let gridRowEnd = GridRowEnd
    let gridRowGap = GridRowGap
    let gridRowStart = GridRowStart
    let gridRow = GridRow
    let gridTemplateAreas = GridTemplateAreas
    let gridTemplateColumns = GridTemplateColumns
    let gridTemplateRows = GridTemplateRows
    let gridTemplate = GridTemplate
    let grid = Grid
    let hangingPunctuation = HangingPunctuation
    let height = Height
    let hyphens = Hyphens
    let isolation = Isolation
    let justifyContent = JustifyContent
    let justifyItems = JustifyItems
    let justifySelf = JustifySelf
    let label = Label
    let left = Left
    let letterSpacing = LetterSpacing
    let lineBreak = LineBreak
    let lineHeight = LineHeight
    let listStyleImage = ListStyleImage
    let listStylePosition = ListStylePosition
    let listStyleType = ListStyleType
    let listStyle = ListStyle
    let marginBottom = MarginBottom
    let marginLeft = MarginLeft
    let marginRight = MarginRight
    let marginTop = MarginTop
    let margin = Margin
    let markerOffset = MarkerOffset
    let marks = Marks
    let maxHeight = MaxHeight
    let maxWidth = MaxWidth
    let minHeight = MinHeight
    let minWidth = MinWidth
    let mixBlendMode = MixBlendMode
    let navUp = NavUp
    let navDown = NavDown
    let navLeft = NavLeft
    let navRight = NavRight
    let opacity = Opacity
    let order = Order
    let orphans = Orphans
    let outlineColor = OutlineColor
    let outlineOffset = OutlineOffset
    let outlineStyle = OutlineStyle
    let outlineWidth = OutlineWidth
    let outline = Outline
    let overflow = Overflow
    let overflowWrap = OverflowWrap
    let overflowX = OverflowX
    let overflowY = OverflowY
    let paddingBottom = PaddingBottom
    let paddingLeft = PaddingLeft
    let paddingRight = PaddingRight
    let paddingTop = PaddingTop
    let padding = Padding
    let pageBreakAfter = PageBreakAfter
    let pageBreakBefore = PageBreakBefore
    let pageBreakInside = PageBreakInside
    let page = Page
    let pauseAfter = PauseAfter
    let pauseBefore = PauseBefore
    let pause = Pause
    let perspective = Perspective
    let perspectiveOrigin = PerspectiveOrigin
    let pitchRange = PitchRange
    let pitch = Pitch
    let placeContent = PlaceContent
    let placeItems = PlaceItems
    let placeSelf = PlaceSelf
    let playDuring = PlayDuring
    let position = Position
    let quotes = Quotes
    let resize = Resize
    let restAfter = RestAfter
    let restBefore = RestBefore
    let rest = Rest
    let richness = Richness
    let right = Right
    let size = Size
    let speakHeader = SpeakHeader
    let speakNumeral = SpeakNumeral
    let speakPunctuation = SpeakPunctuation
    let speak = Speak
    let speechRate = SpeechRate
    let stress = Stress
    let tabSize = TabSize
    let tableLayout = TableLayout
    let textAlign = TextAlign
    let textAlignlast = TextAlignlast
    let textDecoration = TextDecoration
    let textDecorationColor = TextDecorationColor
    let textDecorationLine = TextDecorationLine
    let textDecorationSkip = TextDecorationSkip
    let textDecorationStyle = TextDecorationStyle
    let textIndent = TextIndent
    let textOverflow = TextOverflow
    let textShadow = TextShadow
    let textTransform = TextTransform
    let textUnderlinePosition = TextUnderlinePosition
    let top = Top
    let transform = Transform
    let transformOrigin = TransformOrigin
    let transformStyle = TransformStyle
    let transition = Transition
    let transitionDelay = TransitionDelay
    let transitionDuration = TransitionDuration
    let transitionProperty = TransitionProperty
    let transitionTimingFunction = TransitionTimingFunction
    let unicodeBidi = UnicodeBidi
    let verticalAlign = VerticalAlign
    let visibility = Visibility
    let voiceBalance = VoiceBalance
    let voiceDuration = VoiceDuration
    let voiceFamily = VoiceFamily
    let voicePitch = VoicePitch
    let voiceRange = VoiceRange
    let voiceRate = VoiceRate
    let voiceStress = VoiceStress
    let voiceVolume = VoiceVolume
    let volume = Volume
    let whiteSpace = WhiteSpace
    let widows = Widows
    let width = Width
    let willChange = WillChange
    let wordBreak = WordBreak
    let wordSpacing = WordSpacing
    let wordWrap = WordWrap
    let zIndex = ZIndex
    let hover = Hover