import { Link } from 'react-router-dom';
import { Menu } from 'antd';
import {HomeOutlined,ContainerOutlined,UserOutlined,UsergroupAddOutlined} from '@ant-design/icons';
import "./Nav.scss"
import React from 'react';
import { useLocation } from 'react-router';
const Nav = () => {
    const location = useLocation().pathname.split('/');
    return (
        <Menu mode="inline" theme="dark" className="menu">
            <Menu.Item
                key="category"
                icon={<HomeOutlined />}
                style={{ backgroundColor: location[location.length-1] === 'category' ? 'gray' : '' }}
            >
                <Link to="/admin/category">Category</Link>
            </Menu.Item>
            <Menu.Item
                key="book"
                icon={<ContainerOutlined />}
                style={{ backgroundColor: location[location.length-1] === 'book' ? 'gray' : '' }}
            >
                <Link to="/admin/book">Book</Link>
            </Menu.Item>
            <Menu.Item
                key="user"
                icon={<UserOutlined />}
                style={{ backgroundColor: location[location.length-1] === 'user' ? 'gray' : '' }}
            >
                <Link to="/admin/user">User</Link>
            </Menu.Item>
            <Menu.Item
                key="request"
                icon={<UsergroupAddOutlined />}
                style={{ backgroundColor: location[location.length-1] === 'request' ? 'gray' : '' }}
            >
                <Link to="/admin/request">Request</Link>
            </Menu.Item>
        </Menu>
    );
};

export default Nav;
