console.log("=================状态模式================");
//投票结果状态对象
var ResultState = function() {
    //判断结果保存在内部状态中
    var Status = {
        state0: function() {
            console.log(1);
        },
        state1: function() {
            console.log(2);
        },
        state2: function() {
            console.log(3);
        },
        state3: function() {
            console.log(4);
        }
    };
    //获取一种状态并执行其对应的方法
    function Show(result) {
        Status['state' + result] && Status['state' + result]();
    }
    return {
        Show: Show
    };
}();
ResultState.Show(3);

//状态的优化（模仿超级玛丽）
var MarryState = function() {
    //内部状态私有变量
    var _currentState = {},
        states = {
            jump: function() {
                console.log("跳跃");
            },
            move: function() {
                console.log("移动");
            },
            shoot: function() {
                console.log("射击");
            },
            squat: function() {
                console.log("蹲下");
            }
        };
    //动作控制类
    var Action = {
        //改变状态方法
        changeState: function() {
            //组合动作通过传递多个参数实现
            var arg = arguments;
            //重置内部状态
            _currentState = {};
            //如果有动作则添加动作
            if (arg.length > 0) {
                //遍历动作
                for (var i = 0; i < arg.length; i++) {
                    //向内部状态中添加动作
                    _currentState[arg[i]] = true;
                }
            }
            //返回动作控制类
            return this;
        },
        //执行动作
        goes: function () {
            console.log("触发一次动作");
            //遍历内部状态保存的动作
            for (var i in _currentState) {
                //如果该动作存在则执行
                states[i] && states[i]();
            }
            return this;
        }
    };
    //返回接口方法
    return {
        change: Action.changeState,
        goes: Action.goes
    };
};
var marry = new MarryState();
marry.change("jump", "shoot").goes();
console.log("=================状态模式 End================");