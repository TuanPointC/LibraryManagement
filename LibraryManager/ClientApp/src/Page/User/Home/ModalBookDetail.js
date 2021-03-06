import { Modal, Image } from 'antd';
import { useState } from 'react';
import { success } from '../../../component/Message';
const ModalBookDetail = (props) => {
    const [confirmLoading, setConfirmLoading] = useState(false);

    const handleOk = () => {
        setConfirmLoading(true);
        success("Adding book")
        var allRequest= props.booksRequest
        allRequest.push(props.book)
        props.setBooksRequest(allRequest)
        setTimeout(() => {
            props.setVisible(false);
            setConfirmLoading(false);
        }, 2000);

    };
    const handleCancel = () => {
        props.setVisible(false);
    };

    return (
        <>
            <Modal
                title={props.book.name}
                visible={props.visible}
                onOk={handleOk}
                confirmLoading={confirmLoading}
                onCancel={handleCancel}
                okText="Add to temporary list"
                width={1000}
            >
                <div className="content" style={{display:'flex',justifyContent:'space-between'}}>
                    <Image
                        width={300}
                        src={props.book.urlImage}
                        style={{flex:'1'}}
                    />
                    <div style={{width:'600px'}}>
                        <p><b>Author: </b>{props.book.author}</p>
                        <p><b>Summary: </b>{props.book.summary}</p>
                    </div>
                </div>
            </Modal>
        </>
    )
}
export default ModalBookDetail