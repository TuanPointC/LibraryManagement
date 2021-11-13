import { Table, Space, Button } from 'antd';
import ListRequest from './ListRequest';
import { v4 as uuid } from "uuid";
import { PostRequest } from '../../../Api/RequestApi';
const columns = [
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
const MyRequestContainer = (props) => {
    const BorrowAll = async () => {
        let dateTime = new Date()
        const listRequests = {
            id: uuid(),
            whoRequestId: localStorage.getItem("userId"),
            requestedDate: dateTime,
            status: 'waiting',
            listBooks: props.booksRequest
        }


        const res = await PostRequest(listRequests);
        console.log(res)
    }
    return (
        <div>
            <h1>List Temporary requests</h1>
            <Button type="primary" onClick={BorrowAll}>Borrow All</Button>
            <Table
                columns={columns}
                dataSource={props.booksRequest}
                bordered style={{ margin: '20px 0' }}
                rowKey="id"
            />
            <ListRequest />
        </div>
    )
}
export default MyRequestContainer;