define(['sammy', 'requester', 'jquery-private'], function(Sammy, HTTPRequester, $) {
    var Controller = function(selector, url) {
        function createMessageBox(msg) {
            return $('<div/>')
                .addClass('message-box')
                .append($('<div/>').addClass('author').html(msg.by + ' said:'))
                .append($('<div/>').addClass('message').html(msg.text))

        }

        var reloadMessages = function(url, header) {
            HTTPRequester.getJSON(url, header).then(function(data) {
                var messagesCountToDisplay = 15;
                var chatList = $('<div/>');
                for (var i = data.length - messagesCountToDisplay; i < data.length; i++) {
                    chatList.prepend(createMessageBox(data[i]));
                }
                $(selector).html(chatList);
            });

        };

        var sendMessage = function(url, header, data) {

            HTTPRequester.postJSON(url, header, data).then(function() {
                $('#msg').val('');
            }, function(error) {
                $('body').html(error.responseText);
            });
        };

        function sendData() {
            var msg = {
                user: $('#name').val() || 'Anonymous',
                text: $('#msg').val()

            };
            sendMessage(url, "application/json", msg);
            reloadMessages(url, "application/json");
        }

        return Sammy(selector, function() {
            this.get('#/index', function() {
                setInterval(function() {
                    reloadMessages(url, "application/json");
                }, 1000);

                $('#send-btn').click(function() {
                    sendData();
                });
                $('#msg').on('keydown', function(e) {
                    if (e.keyCode === 13) {
                        sendData();
                    }
                });
            });
        });

    };
    return Controller;
});