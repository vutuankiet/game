var isSelectX = true;

$(document).ready(function () {
    $('#btn-accpet').click(function () {
        var countBox = $('#board-size').val();

        var html = '';

        for (var i = 0; i < countBox; i++) {
            html += '<tr>';
            for (var j = 0; j < countBox; j++) {
                html += '<td><button id="box-' + i + '-' + j + '" class="box"></button></td>';
            }
            html += '</tr>';
        }
        $('#board-game tbody').empty().append(html);
    });

    $('body').on('click', ".box", function () {
        if ($(this).text() == '') {


            isSelectX = !isSelectX;

            var selector = 'O';
            var cssSeclector = 'box-o';

            if (isSelectX) {
                selector = 'X';
                cssSeclector = 'box-x';
            }

            $(this).text(selector).addClass(cssSeclector);
        
            //Kiem tra win
            var arr = $(this).attr('id').split('-');

            var currentRow = arr[1];
            var currentCol = arr[2];

            var row = -1;
            var col = -1;

            var countWin = -1;

            var COUNTWIN = 5;
            //Check ngang
            countWin = 1;
            //Check ngang trai
            row = currentRow;
            col = currentCol - 1;

            while (col >= 0) {
                var element = '#.box' + row + '-' + col;

                if ($(element).text() == selector) {
                    countWin++;
                    col--;
                } else {
                    break;
                }
            }
            if (countWin >= COUNTWIN) {
                showWin();
            }
            //Check ngang trai
            row = currentRow;
            col = currentCol + 1;

            while (col >= 0) {
                var element = '#.box' + row + '-' + col;

                if ($(element).text() == selector) {
                    countWin++;
                    col--;
                } else {
                    break;
                }
            }
            if (countWin >= COUNTWIN) {
                showWin();
            }
        }
    });
});