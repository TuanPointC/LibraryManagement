import { message } from 'antd';
export const success = async (action) => {
    await message
        .loading('Your request in progress..', 1.0)
        .then(() => message.success(action + ' successfully', 1.0))
};

export const failed = (action) => {
    if(typeof(action)==='object'){
        message
        .loading('Your request in progress..', 1.0)
        .then(() => message.error(action.title , 2.5))
    }
    else{
        message
        .loading('Your request in progress..', 1.0)
        .then(() => message.error(action , 2.5))
    }
};