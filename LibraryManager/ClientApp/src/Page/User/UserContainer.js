import { BrowserRouter as Router, Switch, Route, Redirect } from "react-router-dom";
import { MenuUnfoldOutlined, MenuFoldOutlined } from '@ant-design/icons';
import { Layout, Button } from 'antd';
import Nav from './Nav/Nav';
import Home from "./Home/Home";
import MyRequestContainer from "./MyRequest/MyRequestContainer";
import { useState } from "react";
import HeaderComponent from "../../component/HeaderComponent";
import { failed } from "../../component/Message";

const { Footer, Header, Content, Sider } = Layout;
const UserContainer = (props) => {
    const screenHeight = window.innerHeight - 60 - 60;
    const [collapsed, setCollapsed] = useState(false)
    const [booksRequest, setBooksRequest] = useState([])
    if (!props.userLogin) {
        failed("You need login before access the website")
        return <Redirect to="/login" />
    }
    return (
        <Layout className="layout App">
            <Router>
                <Header style={{ height: '60px', background: '#40A9FF' }}>
                    <HeaderComponent setUserLogin={props.setUserLogin}/>
                </Header>
                <Layout style={{ maxHeight: screenHeight + 'px' }}>
                    <Sider style={{ maxHeight: screenHeight + 'px' }} collapsed={collapsed}>
                        <Button type="primary" onClick={() => setCollapsed((prev) => !prev)} style={{ margin: 16 }}>
                            {collapsed ? <MenuUnfoldOutlined /> : <MenuFoldOutlined />}
                        </Button>
                        <Nav />
                    </Sider>

                    <Content className="site-layout" style={{ padding: '0 20px 0 20px', marginTop: 10, overflowY: 'scroll', maxHeight: screenHeight + 'px', minHeight: screenHeight + 'px' }}>
                        <Switch style={{ padding: 24, minHeight: 380 }}>
                            <Route exact path="/user/">
                                <Home booksRequest={booksRequest} setBooksRequest={setBooksRequest} />
                            </Route>
                            <Route exact path="/user/my-request">
                                <MyRequestContainer booksRequest={booksRequest} setBooksRequest={setBooksRequest} />
                            </Route>
                        </Switch>
                    </Content>

                </Layout>
                <Footer style={{ textAlign: 'center', height: '60px', background: '#40A9FF', zIndex: '1000' }}>Ant Design ©2018 Created by Ant UED</Footer>
            </Router>
        </Layout>
    )
}

export default UserContainer;