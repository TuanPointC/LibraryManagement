import { BrowserRouter as Router, Switch, Route, Redirect } from "react-router-dom";
import { Layout } from 'antd';
import Nav from './Nav/Nav';
import User from './User/User';
import Category from './Category/Category';
import Request from './Request/Request';
import Book from './Book/Book';
import UpdateUser from "./User/UpdateUser";
import UpdateCategory from "./Category/UpdateCategory";
import UpdateBook from "./Book/UpdateBook";

const { Footer, Header, Content, Sider } = Layout;

const AdminContainer = () => {

    return (
        <Layout className="layout App">
            <Router>
                <Header>
                    This is Header
                </Header>
                <Layout>
                    <Sider>
                        <Nav />
                    </Sider>

                    <Content className="site-layout" style={{ padding: '0 60px', marginTop: 10 }}>
                        <Switch style={{ padding: 24, minHeight: 380 }}>
                            <Route exact path="/admin/">
                                <Redirect to="/admin/category" />
                            </Route>
                            <Route exact path="/admin/category">
                                <Category />
                            </Route>
                            <Route path="/admin/category/:id" >
                                <UpdateCategory />
                            </Route>
                            <Route exact path="/admin/book">
                                <Book />
                            </Route>
                            <Route path="/admin/book/:id" >
                                <UpdateBook />
                            </Route>
                            <Route exact path="/admin/request" >
                                <Request />
                            </Route>
                            <Route exact path="/admin/user" >
                                <User />
                            </Route>
                            <Route path="/admin/user/:id" >
                                <UpdateUser />
                            </Route>

                        </Switch>
                    </Content>

                </Layout>
                <Footer style={{ textAlign: 'center' }}>Ant Design ©2018 Created by Ant UED</Footer>
            </Router>
        </Layout>
    )
}

export default AdminContainer;