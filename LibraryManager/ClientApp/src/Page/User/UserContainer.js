import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import {  MenuUnfoldOutlined, MenuFoldOutlined } from '@ant-design/icons';
import { Layout,Button } from 'antd';
import Nav from './Nav/Nav';
import Home from "./Home/Home";
import MyRequest from "./MyRequest/MyRequest";
import { useState } from "react";
import HeaderComponent from "../../component/HeaderComponent";

const { Footer, Header, Content, Sider } = Layout;
const UserContainer = () => {
    const screenHeight = window.innerHeight - 60 - 60;
    const [collapsed, setCollapsed] = useState(false)

    return (
        <Layout className="layout App">
            <Router>
                <Header style={{ height: '60px',background:'#40A9FF' }}>
                    <HeaderComponent/>
                </Header>
                <Layout style={{ maxHeight: screenHeight + 'px' }}>
                    <Sider style={{ maxHeight: screenHeight + 'px' }} collapsed={collapsed}>
                        <Button type="primary" onClick={() => setCollapsed((prev) => !prev)} style={{ margin: 16 }}>
                            {collapsed?<MenuUnfoldOutlined/> : <MenuFoldOutlined/>}
                        </Button>
                        <Nav />
                    </Sider>

                    <Content className="site-layout" style={{ padding: '0 20px 0 20px', marginTop: 10, overflow: 'scroll', maxHeight: screenHeight + 'px', minHeight: screenHeight + 'px' }}>
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
                <Footer style={{ textAlign: 'center', height: '60px' }}>Ant Design ©2018 Created by Ant UED</Footer>
            </Router>
        </Layout>
    )
}

export default UserContainer;