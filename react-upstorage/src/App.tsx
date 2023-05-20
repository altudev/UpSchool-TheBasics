import {useState} from 'react';
import './App.css'
import NavBar from './components/NavBar.tsx';

function App() {

    const [password, setPassword] = useState<string>("123456");

    return (
        <>
            <NavBar />
            <div className="container" style={{backgroundColor: "#C4DFDF"}}>
                <div className="card-header is-justify-content-center">
                    <h3 className="has-text-success is-size-2">Secure Password Generator</h3>
                </div>
                <div className="card">

                    <div className="card-content">
                        <div className="media">
                            <div className="media-content">
                                <p className="is-size-3">{password}</p>
                            </div>
                            <div className="media-right">
                                <i className="is-size-3">📋</i>
                                <i className="is-size-3">♻️</i>
                            </div>
                        </div>

                        <div className="content">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                            Phasellus nec iaculis mauris. <a>@bulmaio</a>.
                            <a href="#">#css</a> <a href="#">#responsive</a>
                            <br/>
                            <time dateTime="2016-1-1">11:09 PM - 1 Jan 2016</time>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}

export default App
