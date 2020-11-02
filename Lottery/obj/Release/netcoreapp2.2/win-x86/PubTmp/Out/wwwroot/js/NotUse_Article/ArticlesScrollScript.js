


class ScrollArticle {
    constructor(options) {
        if (options != undefined) {
            this.$ScrollUp = options.$ScrollUp;
            this.$ScrollDown = options.$ScrollDown;
            this.CurrentPage = options.CurrentPage;
        }

        var ScrollUp = function func() {
            console.log("Scrolling up");
            this.ScrollingUp();
        }
        var ScrollDown = function func() {
            console.log("Scrolling down");
            this.ScrollingDown();
        }

        ScrollUp = bindFunc(ScrollUp, this);
        ScrollDown = bindFunc(ScrollDown, this);

        this.$ScrollUp.on("click", ScrollUp);
        this.$ScrollDown.on("click", ScrollDown);
    }


    ScrollingUp() {
        $.ajax({
            url: '/News/GetNews?week=' + ( Number(this.CurrentPage) + 1),
            type: 'POST',
            success: function (data) {
                console.log(data);
            },
            failure:
                function (data) {
                    console.log(data);
                },
        });
    }

    ScrollingDown() {

    }
}