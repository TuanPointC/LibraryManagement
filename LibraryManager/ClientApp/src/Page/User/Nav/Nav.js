import { Link } from 'react-router-dom';
import { Menu } from 'antd';
import { HomeOutlined, ContainerOutlined} from '@ant-design/icons';
import "./Nav.scss"
import React from 'react';
import { useLocation } from 'react-router';

const Nav = () => {
    const location = useLocation().pathname.split('/');
    return (

            <Menu mode="inline" theme="dark" >
                <Menu.Item
                    key="home"
                    icon={<HomeOutlined />}
                    style={{ backgroundColor: location[location.length - 1] === 'user' ? '#40A9FF' : '' }}
                >
                    <Link to="/user">Home</Link>
                </Menu.Item>
                <Menu.Item
                    key="my-request"
                    icon={<ContainerOutlined />}
                    style={{ backgroundColor: location[location.length - 1] === 'my-request' ? '#40A9FF' : '' }}
                >
                    <Link to="/user/my-request">My Request</Link>
                </Menu.Item>

            </Menu>
    );
};

export default Nav;
