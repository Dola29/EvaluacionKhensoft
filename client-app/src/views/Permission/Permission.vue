<template>
    <div class="mt-3 col-12">
        <div class="row justify-content-center">
            <div class="col-12">
                <div class="card">
                    <div class="card-header">
                        <h3 class="h3 float-left">Permissions Dashboard</h3>
                        <button class="btn btn-primary btn-sm float-right" @click="create()">Add 
                            <b-icon icon="plus" font-scale="1" aria-hidden="true">
                        </b-icon></button>
                    </div>
                    <div class="card-body ">
                        <div class="row p-3">                             
                            <label class="ml-3 mr-3" label-for="perPageSelect">Per Page</label>
                            <b-form-select style="width:70px"
                                    v-model="perPage"
                                    id="perPageSelect"
                                    :options="pageOptions"
                                ></b-form-select>
                            </b-form-group>
                        </div>
                        <b-table class="col-12"
                            bordered
                            striped
                            small
                            responsive 
                            :current-page="currentPage"
                            :per-page="perPage"
                            :items="items"
                            :fields="fields"
                            :sort-by.sync="sortBy"
                            :sort-desc.sync="sortDesc"
                            sort-icon-left
                            responsive="sm">
                            <template v-slot:cell(Name)="row">
                                {{row.item.employeeName}}
                            </template>
                            <template v-slot:cell(employeeLastname)="row">
                                {{row.item.employeeLastName}}
                            </template>
                            <template v-slot:cell(permissionType)="row">
                                {{row.item.permissionType.description}}
                            </template>
                            <template v-slot:cell(permissionDate)="row">
                                {{row.item.permissionDate | myDate}}
                            </template>

                            <template v-slot:table-colgroup="scope">                            
                                <col
                                v-for="field in scope.fields"
                                :key="field.key"
                                :style="{ width: field.key === 'action' ? '180px' : ''}"
                                >
                            </template>

                            <template v-slot:cell(action)="row">
                                <b-button size="sm" @click="row.toggleDetails" class="mr-2" variant="secondary">
                                    {{ row.detailsShowing ?  'Hide' : 'Show'}} <b-icon icon="eye" aria-hidden="true"></b-icon>
                                </b-button>
                                <b-button size="sm" variant="warning" class="mr-2" @click="edit(row.item)">
                                    <b-icon icon="pencil" aria-hidden="true"></b-icon>
                                </b-button>
                                <b-button size="sm" variant="danger" @click="deletePermission(row.item)">
                                    <b-icon icon="trash" aria-hidden="true"></b-icon>
                                </b-button>
                            </template>

                            <template v-slot:row-details="row">
                                <b-card>
                                <b-row>
                                    <div class="col-6">
                                        <b-row class="mb-2">
                                            <b-col sm="6" class="text-sm-right"><b>Name:</b></b-col>
                                            <b-col sm="6">{{ row.item.employeeName }}</b-col>
                                            <b-col sm="6" class="text-sm-right"><b>Permission Type:</b></b-col>
                                            <b-col sm="6">{{ row.item.permissionType.description}}</b-col>
                                        </b-row>
                                    </div> 
                                    <div class="col-6">
                                        <b-row class="mb-2">
                                            <b-col sm="6" class="text-sm-right"><b>Lastname:</b></b-col>
                                            <b-col sm="6" >{{ row.item.employeeLastName }}</b-col>
                                            <b-col sm="6" class="text-sm-right"><b>Date:</b></b-col>
                                            <b-col sm="6" >{{ row.item.permissionDate | myDate }}</b-col>
                                        </b-row>    
                                    </div> 
                                </b-row>    
                                
                                <b-button size="sm" @click="row.toggleDetails" variant="secondary">Hide Details</b-button>
                                </b-card>
                            </template>
                        
                        </b-table>
                        <div class="row pl-3 pr-3">
                            <div class="col-3">
                                <b-pagination
                                    v-model="currentPage"
                                    :total-rows="totalRows"
                                    :per-page="perPage"
                                    align="fill"
                                    size="sm"
                                    class="my-0"
                                >
                                
                                </b-pagination>
                            </div>
                            <div class="col-5"></div>
                            <div class="col-4 text-right">
                                Sort By: <b>{{ sortBy }}</b>, Order:
                                <b>{{ sortDesc ? 'Desc' : 'Asc' }}</b>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <b-modal id="modal-1" >
            <template #modal-title>
                <span v-if="!editMode">Create Permission</span>
                <span v-if="editMode">Edit Permission</span>
            </template>
            <div class="d-block">
                <form>                    
                    <div class="row">
                        <div class="form-group col-12">
                            <label>Employee Name</label>
                            <input v-model="permission.employeeName" type="text" name="empresa" class="form-control">
                        </div>
                        <div class="form-group col-12">
                            <label>Employee Lastname</label>
                            <input v-model="permission.employeeLastName" type="text" name="contacto" class="form-control" >
                        </div>                    
                        <div class="form-group col-12">
                            <label>Permission Type</label>
                            <select class="form-control" v-model="permission.permissionTypeId">
                                <option v-for="permision in permissionTypeOptions" :value="permision.id">{{permision.description}}</option>
                            </select>
                        </div>
                        <div class="form-group col-12">
                            <label>Permission Date</label>
                            <b-form-datepicker
                                id="fecha_expiracion"
                                v-model="permission.permissionDate"
                                :date-format-options="{ year: 'numeric', month: 'numeric', day: 'numeric' }"
                                locale="es"
                                placeholder="Select A date"
                            ></b-form-datepicker>
                        </div>                                
                    </div>                     
                </form>
            </div>   
            <template #modal-footer>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" @click="close()">
                        Cancel <b-icon icon="exclamation-circle" variant=""></b-icon>
                    </button>
                    <button v-show="editMode" type="submit" class="btn btn-warning" @click="update()">
                        Update <b-icon icon="cloud-upload" aria-hidden="true"></b-icon>
                    </button>
                    <button v-show="!editMode" type="submit" class="btn btn-success" @click="save()">
                        Save <b-icon icon="cloud-upload" aria-hidden="true"></b-icon>
                    </button>
                </div>
            </template>         
        </b-modal>

    </div>
</template>

<script>
export default {
    created() {
        this.getPermissions();
        this.getPermissionTypes();
    },
    data() {
            return {
                pageOptions: [5, 10, 15],
                currentPage: 1,
                perPage: 5,
                sortBy: 'employeeName',
                sortDesc: false,
                fields: [
                    { key: 'employeeName', sortable: true, class:'text-left' },
                    { key: 'employeeLastname', sortable: true, class:'text-left' },
                    { key: 'permissionType', sortable: true , class:'text-left' },
                    { key: 'permissionDate', sortable: true },
                    { key: 'action'}
                ],
                items: [],
                totalRows:0,
                permissionTypeOptions: [],
                permission:{
                    id: null,
                    employeeName: null,
                    employeeLastName: null,
                    permissionTypeId: null,
                    permissionDate: null
                },
                editMode: false
                }
    },
    methods:{
        getPermissions(){
            axios.get(be_url+'/permission')
            .then(response => {
                let data =  response.data;
                this.items = data;
                this.totalRows = data.length
            })
            .catch(errors => {
                console.log(errors);
            });
        },
        deletePermission(permission){
            swal.fire({
                title: 'Are you sure?',
                text: "You can not revert this action!",
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes!'
            }).then((result) => {
                if (result.value) { 
                    axios.delete(be_url+'/permission', {data:permission}).then(()=>{ 
                        this.getPermissions();
                        swal.fire(
                            'Deleted!',
                            'Permission Deleted',
                            'success'
                        );                              
                    }).catch(()=>{
                        swal.fire('Error!','There was an error','error');                            
                    });
                }
                
            });

            
        },
        getPermissionTypes(){
            axios.get(be_url+'/permissionType')
            .then(response => {
                this.permissionTypeOptions = response.data;       
            })
            .catch(errors => {
                console.log(errors);
            });
        },
        clearform(){
            this.permission.employeeName = null;
            this.permission.employeeLastName = null;
            this.permission.permissionTypeId = null;
            this.permission.permissionDate = null;
            this.permission.id = 0;
        },
        create() {
            this.clearform();
            this.editMode = false;
            this.$root.$emit('bv::show::modal', 'modal-1', '#btnShow');
        },
        close(){
            this.$root.$emit('bv::hide::modal', 'modal-1', '#btnShow')
        },
        save(){
            if(!this.permission.employeeName || !this.permission.employeeLastName  || !this.permission.permissionTypeId || !this.permission.permissionDate){
                swal.fire('Error!','All Fields are required','error');
            }else{
                axios.post(be_url+'/permission',this.permission)
                .then(()=>{
                    this.clearform();
                    this.getPermissions();
                    this.$root.$emit('bv::hide::modal', 'modal-1', '#btnShow');
                    toast.fire({
                        icon: 'success',
                        title: 'The info was Saved!!!'
                    }); 
                })
                .catch(function (error) {
                    console.log(error);
                });      
            }
        
        },
        edit(permission){
            this.editMode = true;
            this.$root.$emit('bv::show::modal', 'modal-1', '#btnShow');
            this.permission.id = permission.id,
            this.permission.employeeName =  permission.employeeName;
            this.permission.employeeLastName =  permission.employeeLastName;
            this.permission.permissionTypeId =  permission.permissionTypeId;
            this.permission.permissionDate =  permission.permissionDate; 
            
        },
        update(){
            if(!this.permission.employeeName || !this.permission.employeeLastName  || !this.permission.permissionTypeId || !this.permission.permissionDate){
                swal.fire('Error!','All Fields are required','error');
            }else{
                axios.put(be_url+'/permission',this.permission)
                .then(()=>{
                    this.getPermissions();
                    this.$root.$emit('bv::hide::modal', 'modal-1', '#btnShow');
                    toast.fire({
                        icon: 'success',
                        title: 'The info was Saved!!!'
                    }); 
                })
                .catch(function (error) {
                    console.log(error);
                });      
            }
        }
    }
}
</script>

<style>

</style>