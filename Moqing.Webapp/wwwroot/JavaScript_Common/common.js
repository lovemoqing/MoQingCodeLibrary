//JavascriptCommon
var Common = function () {
    var _this = this;
    //获取当前的系统时间
    _this.GetCurrSystemTime = function () {
        function add(m) {
            return m < 10 ? '0' + m : m
        }
        function fortime() {
            var date = new Date();
            var y = date.getFullYear();
            var m = date.getMonth() + 1;
            var d = date.getDate();
            var h = date.getHours();
            var mm = date.getMinutes();
            var s = date.getSeconds();
            return (y + '' + add(m) + '' + add(d) + '' + add(h) + '' + add(mm) + '' + add(s));
        }
        return fortime()
    }
}
//实例化组件
var common = new Common();
//调用
common.GetCurrSystemTime()