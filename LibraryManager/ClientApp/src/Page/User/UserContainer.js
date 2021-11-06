import {
    BrowserRouter as Router,
    Switch,
    Route
} from "react-router-dom";
import { Layout } from 'antd';
import Nav from './Nav/Nav';
import Home from "./Home/Home";
import MyRequest from "./MyRequest/MyRequest";

const { Footer, Header, Content, Sider } = Layout;
const UserContainer = () => {
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
                            <Route exact path="/user">
                                <Home />
                            </Route>
                            <Route exact path="/user/my-request">
                                <MyRequest />
                            </Route>
                            
                        </Switch>
                    </Content>

                </Layout>
                <Footer style={{ textAlign: 'center' }}>Ant Design ©2018 Created by Ant UED</Footer>
            </Router>
        </Layout>
    )
}

export default UserContainer;