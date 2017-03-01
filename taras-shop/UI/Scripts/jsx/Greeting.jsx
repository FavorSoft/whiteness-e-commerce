class Greeting extends React.Component {
    render() {
        return (
          <div className="greeting-block">
            Hello, world! I am a GreetingBox.
          </div>
      );
    }
};
ReactDOM.render(
  <Greeting/>,
  document.getElementById('greet')
);