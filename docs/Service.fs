namespace Docs

module Service =
    open Thoth.Fetch

    let inline getMarkdown (markdown: string) =
        promise {
            return! Fetch.get($"https://raw.githubusercontent.com/Bjorn-Strom/FSS/master/documentation/{markdown}.md")
        }