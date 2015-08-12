$(document).ready(function () {

    var Shape = function () {
        const lineChar = "X";

        var middle = function (text, size) {
            var len = Math.floor((text.length - size) / 2);
            regex = new RegExp("(.*)(.{" + size + "})(.{" + len + "})");
            return text.replace(regex, "$2");
        };

        var centerText = function (innerText, outerText) {
            var regex;
            var len = innerText.length;
            var size = outerText.length;
            var centeredText;

            if (len <= size) {
                regex = new RegExp("(.*)(.{" + len + "})(\\1)$");
                centeredText = outerText.replace(regex, "$1" + innerText + "$3");
            } else
                centeredText = middle(innerText, size);
            return centeredText;
        };

        var printLabel = function (currentRow, label, labelRow) {
            return label && labelRow == currentRow;
        };

        var createUpTriangle = function (height, label, labelRow) {
            var shape = "";

            for (i = 1; i <= height; i++) {
                shape = shape.concat(Array(height + 1 - i).join("&nbsp;"));
                var line = Array(i + 1).join(lineChar);
                if (printLabel(i, label, labelRow))
                    line = centerText(label, line);
                shape = shape.concat(line, "</br>");
            }
            return shape;
        };

        var createDownTriangle = function (height, label, labelRow) {
            var shape = "";

            for (i = height; i > 0; i--) {
                shape = shape.concat(Array(height + 2 - i).join("&nbsp;"));
                var line = Array(i + 1).join(lineChar);
                if (printLabel(i, label, labelRow))
                    line = centerText(label, line);
                shape = shape.concat(line, "</br>");
            }
            return shape;
        };

        var createDiamond = function (height, label, labelRow) {
            var shape = createUpTriangle(Math.ceil(height / 2), label, labelRow);
            return shape.concat(createDownTriangle(Math.floor(height / 2), label, height - labelRow + 1));
        };

        var createBox = function (height, label, labelRow) {
            var shape = "";

            for (i = 1; i <= height; i++) {
                var line = Array(height + 1).join(lineChar);
                if (printLabel(i, label, labelRow))
                    line = centerText(label, line);
                shape = shape.concat(line, "</br>");
            }
            return shape;
        };

        var createRectangle = function (height, label, labelRow) {
            var shape = "";
            var rectangleHeight = (height + 1) * 2;

            for (i = 1; i <= height; i++) {
                var line = Array(rectangleHeight).join(lineChar);
                if (printLabel(i, label, labelRow))
                    line = centerText(label, line);
                shape = shape.concat(line, "</br>");
            }
            return shape;
        };

        var draw = function () {
            var shape = "";
            var label = $("#Shape_Label").val();
            var labelRow = $("#Shape_LabelRow").val() === "" ? 0 : parseInt($("#Shape_LabelRow").val());
            var height = $("#Shape_Height").val() === "" ? 0 : parseInt($("#Shape_Height").val());
            var selectedShape = $("#Shape_ShapeTypeId option:selected").text();

            switch (selectedShape.toLowerCase()) {
                case "triangle": shape = createUpTriangle(height, label, labelRow); break;
                case "diamond": shape = createDiamond(height, label, labelRow); break;
                case "rectangle": shape = createRectangle(height, label, labelRow); break;
                default: shape = createBox(height, label, labelRow);
            }
            $("#shape").html(shape);
        };

        return {
            Draw: draw
        };
    };

    if (isValid) {
        var shape = Shape();
        shape.Draw();
    }
});