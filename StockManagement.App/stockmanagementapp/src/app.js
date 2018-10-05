import React from 'react'
import Navigation from './components/Navigation';


class App extends React.Component{
    render(){
        return(
            <div>
                <Navigation />
                <div className="container">           
                    <h1>My Blog</h1>
                </div>
           </div>
        );
    }
}

export default App;