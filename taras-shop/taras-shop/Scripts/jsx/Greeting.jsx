var Greeting = React.createClass({
    render: function() {
        return (
          <div className="greeting-block">
            Hello, world! I am a GreetingBox.
          </div>
      );
    }
});
ReactDOM.render(
  <Greeting/>,
  document.getElementById('content')
);