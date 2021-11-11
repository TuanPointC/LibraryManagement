import { Menu, Dropdown, Avatar } from 'antd';
import { UserOutlined } from '@ant-design/icons';
const menu = (
    <Menu >
        <Menu.Item style={{padding:'5px 30px'}}>
            Profile
        </Menu.Item>
        <Menu.Item style={{padding:'5px 30px'}}>
            Sign out
        </Menu.Item>
        <Menu.Item style={{padding:'5px 30px'}}>
            Settings
        </Menu.Item>
    </Menu>
);
const HeaderComponent = () => {
    return (
        <div style={{ display: 'flex', alignItems: 'center', height: '60px' }}>
            <div style={{ flex: "1", fontWeight: 'bold', fontSize: '25px', textShadow: '6px 6px 0px rgba(0,0,0,0.2)' }}>Library Management</div>
            <div style={{ flex: "1" }}>Wellcome Name User</div>
            <div>
                <Dropdown overlay={menu} placement="bottomCenter" arrow>
                    <Avatar size={40} icon={<UserOutlined />} style={{cursor:'pointer'}}/>
                </Dropdown>
            </div>
        </div>
    )
}

export default HeaderComponent;