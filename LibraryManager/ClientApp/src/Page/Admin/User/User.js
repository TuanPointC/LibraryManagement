import { useState, useEffect } from "react";
import { GetUsers } from "../../../Api/UserApi";
import ModalAddingUser from "./ModalAddingUser";
import { Spin, Table, Button, Space } from 'antd';
import { Link, useRouteMatch } from "react-router-dom";

const User = () => {
    const [user, setUser] = useState([])
    const [isLoading, setisLoading] = useState(false)
    const [rowWasEntered, setRowWasEntered] = useState(null)
    let { url } = useRouteMatch();
    

    useEffect(() => {
        async function getUser() {
            setUser(await GetUsers())
            setisLoading(false);
        }
        getUser()
    }, [])

    const columns = [
        {
            title: 'Id',
            dataIndex: 'id',
        },
        {
            title: 'Name',
            dataIndex: 'name',
        },
        {
            title: 'Email',
            dataIndex: 'email',
        },
        {
            title: 'Password',
            dataIndex: 'password',
        },
        {
            title: 'Role',
            dataIndex: 'role',
        },
        {
            title: "Actions",
            align: 'right',
            size: "small",
            render: () => (
                <Space size="large">
                    <Button type="primary"><Link to={`${url}/${rowWasEntered}`}>Edit</Link></Button>
                </Space>
            )

        }
    ];

    if (isLoading) {
        return <Spin size="large" style={{ position: 'absolute', top: '50%', left: '50%', translate: '-50%,-50%' }} />
    }
    return (
        <div>

            <ModalAddingUser
                user={user}
                setUser={setUser}
            />

            <Table
                columns={columns}
                dataSource={user}
                bordered style={{ margin: '20px 0' }}
                rowKey="id"
                onRow={(record) => {
                    return {
                        onMouseEnter: () => { setRowWasEntered(record.id) },
                    }
                }}
            />
        </div>
    )
}
export default User;