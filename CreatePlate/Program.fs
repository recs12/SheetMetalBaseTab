open System
open SolidEdgeCommunity.Extensions

(*
This code create a Part:
    SheetMetal -> Tab
*)

[<STAThread>]
[<EntryPoint>]
let main argv =
    let application = SolidEdgeCommunity.SolidEdgeUtils.Connect(true, true)
    let documents = application.Documents;
    let sheetMetalDocument = documents.AddSheetMetalDocument()
    let model = SheetMetalHelper.CreateBaseTab(sheetMetalDocument)
    let tabs = model.Tabs
    let tab = tabs.Item(1)
    let mutable selectSet = application.ActiveSelectSet
    selectSet.RemoveAll()
    selectSet.Add(tab)
    application.StartCommand(SolidEdgeConstants.SheetMetalCommandConstants.SheetMetalViewISOView);
    0