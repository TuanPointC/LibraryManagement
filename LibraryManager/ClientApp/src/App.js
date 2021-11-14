import './App.scss';
import { BrowserRouter as Router, Route, Switch, Redirect } from "react-router-dom";
import React from 'react';
import AdminContainer from './Page/Admin/AdminContainer';
import UserContainer from './Page/User/UserContainer';
import Login from './Page/LogPage/Login';
import NotMatch from './Page/NotMatch/NotMatch';
import { useState } from 'react'

function App() {
  const [userLogin, setUserLogin] = useState(false)
  useState(() => {
    if (localStorage.getItem("token")) {
      setUserLogin(true)
    }
  }, [])
  return (
    <Router>
      <Switch>

        <Route exact path="/">
          <Redirect to="/user" />
        </Route>

        <Route path="/user">
          <UserContainer userLogin={userLogin} setUserLogin={setUserLogin} />
        </Route>

        <Route path="/admin">
          <AdminContainer userLogin={userLogin} setUserLogin={setUserLogin} />
        </Route>

        <Route path="/login">
          <Login userLogin={userLogin} setUserLogin={setUserLogin} />
        </Route>

        <Route >
          <NotMatch />
        </Route>

      </Switch>
    </Router>



  );
}

export default App;
