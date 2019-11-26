var gridData = {
    Head: [["Header 1", "Header 2", "Header 3"]],
    Body: [["Row 1, Cell 1", "Row 1, Cell 2", "Row 1, Cell 3"],
        ["Row 2, Cell 1", "Row 2, Cell 2", "Row 2, Cell 3"],
    ["Row 3, Cell 1", "Row 3, Cell 2", "Row 3, Cell <em>3</em>"]]
};



new Grid("myGrid", {
    srcType: "json",
    srcData: gridData,
    allowGridResize: true,
    allowColumnResize: true,
    allowClientSideSorting: true,
    allowSelections: true,
    allowMultipleSelections: true,
    showSelectionColumn: true,
    fixedCols: 1
});