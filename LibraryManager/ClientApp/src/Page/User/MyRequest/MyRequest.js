import { Table, Space, Button } from 'antd';
const columns = [
    {
        title: 'Id',
        dataIndex: 'id',
    },
    {
        title: 'Name',
        dataIndex: 'name',
        ellipsis: true,
    },
    {
        title: 'Author',
        dataIndex: 'author',
        ellipsis: true,
    },
    {
        title: 'Url Image',
        dataIndex: 'urlImage',
        ellipsis: true,
    },
    {
        title: 'Summary',
        dataIndex: 'summary',
        ellipsis: true,
    },
    {
        title: 'Category',
        dataIndex: 'categoryId',
        ellipsis: true,
    },
    {
        title: 'Category',
        dataIndex: 'category',
        ellipsis: true,
    },
    {
        title: "Actions",
        with: 80,
        align: 'right',
        size: "small",
        render: () => (
            <Space size="large">
                <Button type="danger">Delete</Button>
            </Space>
        ),

    }
];
const MyRequest = (props) => {
    return (
        <div>
            <Button type="primary">Confirm</Button>
            <Table
                columns={columns}
                dataSource={props.request}
                bordered style={{ margin: '20px 0' }}
                rowKey="id"
            />
        </div>
    )
}
export default MyRequest;