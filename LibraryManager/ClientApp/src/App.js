import './App.scss';
import { BrowserRouter as Router, Route, Switch, Redirect } from "react-router-dom";
import React from 'react';
import AdminContainer from './Page/Admin/AdminContainer';
import UserContainer from './Page/User/UserContainer';
import Login from './Page/LogPage/Login';


function App() {

  return (

    <Router>
      <Switch>
        
        <Route exact path="/">
          <Redirect to="/user" />
        </Route>

        <Route path="/user">
          <UserContainer />
        </Route>

        <Route path="/admin">
          <AdminContainer />
        </Route>

        <Route path="/login">
          <Login/>
        </Route>

      </Switch>
    </Router>



  );
}

export default App;
