define('jquery-private', ['jquery'], function($) {
    return $.noConflict(true);
});
(function() {

    require.config({
        paths: {
            sammy: './bower_components/sammy/lib/min/sammy-latest.min',
            requester: 'http-requester',
            controller: 'controller',
            jquery: './bower_components/jquery/dist/jquery.min'
        }
    });

    require(['controller', 'jquery-private'],
        function(Controller, $) {
            var selector = '#chat-container',
                url = 'http://crowd-chat.herokuapp.com/posts',
                crowdChat = Controller(selector, url);
            crowdChat.run('#/index');
        });
}());