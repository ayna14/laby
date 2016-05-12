$(document).ready(function () {

    function viewModel() {
        this.notepadName = ko.observable("");
        this.notepadSelected = ko.observable("");
        var notepadList = [];

        this.createNotepad = function () {
            $.post("/Home/CreateNotepad", { NoteName: this.notepadName() });
            addNotepad(this.notepadName());
        };
           
        this.saveContent = function () {
            var c = $('#notepadContent').val();
            $.post("/Home/SetContent", { NoteName: notepadSelected, NoteContent: c });
        };

        this.select = function () {
            $('#notepadList').click(function (event) {
                notepadSelected = event.target.innerHTML;
                createImage(notepadSelected);
                loadContent(notepadSelected);
            });
        };

        function loadContent(n) {
            $.post("/Home/LoadContent", { NoteName: n }).success(function (data) {
                $('#notepadContent').val(data);
            });
        };

        function addNotepad(n) {
                notepadList.push(n);
                var list = document.getElementById('notepadList');
                var li = document.createElement('li');
                li.innerHTML = n;
                list.appendChild(li)
        };

        function createImage(str) {
        $.post("/Home/CreateImage", { notepad: str });
        $('img').attr('src', '/Content/'+ str +'.jpg');
    };

        this.loadNotepads = function () {
            $('#notepadList').text('');
            $.post("/Home/LoadNotepads").success(function (data) {
                for (var i = 0; i < data.length; i++) {
                    addNotepad(data[i].Name);
                }
            });
        };
    };
    ko.applyBindings(new viewModel());
    
    var vm = new viewModel();
    vm.loadNotepads();
});

function GetNotepad(Notepad) {
            $.post("/Home/LoadContent", { NoteName: Notepad }).success(function (data) {
            $('#notepadContent').val(data);
            $.post("/Home/CreateImage", { notepad: Notepad });
            $('img').attr('src', '/Content/' + Notepad + '.jpg');
        });
    
};