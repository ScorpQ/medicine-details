
import './App.css';

function App() {
  return (
  <div className={"mainContainer"}>
    <div className={"titleContainer"}>
        <div>Login</div>
    </div>
    <br />
    <div className={"inputContainer"}>
        <input
            placeholder="Enter your email here"
            className={"inputBox"} />
        <label className="errorLabel"></label>
    </div>
    <br />
    <div className={"inputContainer"}>
        <input 
            placeholder="Enter your password here"
            className={"inputBox"} />
        <label className="errorLabel"></label>
    </div>
    <br />
    <div className={"inputContainer"}>
        <input
            className={"inputButton"}
            type="button"
    
            value={"Log in"} />
    </div>
</div>
  );
}

export default App;
