import React from 'react';
import { List, SelectField,Datagrid,ReferenceField, TextField ,EditButton,Edit,SimpleForm,SelectInput,Create, TextInput,DateInput,NumberInput,ReferenceInput  } from 'react-admin';

const choices = [
    { id: 1, name: 'Admin' },
    { id: 2, name: 'Contributor' },
 ];

export const UserAccessList = (props) => (
    <List {...props}>
        <Datagrid>           
            <ReferenceField label="UserName" source="userId" reference="users">
                <TextField source="username" />
            </ReferenceField>

            <ReferenceField label="Company" source="companyId" reference="company">
                <TextField source="name" />
            </ReferenceField>

            <SelectField  source="role" choices={choices} translateChoice={false}/>
            <EditButton />
        </Datagrid>
    </List>
);


