import { BrowserRouter as Router, Switch, Route, Redirect } from "react-router-dom";
import { Layout } from 'antd';
import Nav from './Nav/Nav';
import User from './User/User';
import Category from './Category/Category';
import Request from './Request/Request';
import Book from './Book/Book';
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
                            <Route exact path="/admin/book">
                                <Book />
                            </Route>
                            <Route exact path="/admin/request" >
                                <Request />
                            </Route>
                            <Route exact path="/admin/user" >
                                <User />
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